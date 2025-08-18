using AuditTrail.API.Enums;
using AuditTrail.API.Services.Interfaces;
using AuditTrail.Models;
using System.Reflection;

namespace AuditTrail.API.Services
{
  public class AuditService : IAuditService
  {
    /// <summary>
    /// Creates an audit log entry for the specified action, comparing before and after states.
    /// </summary>
    /// <typeparam name="T">The type of the entity being audited.</typeparam>
    /// <param name="before">The state of the entity before the action (null for Created).</param>
    /// <param name="after">The state of the entity after the action (null for Deleted).</param>
    /// <param name="action">The type of audit action (Created, Updated, Deleted).</param>
    /// <param name="userId">The ID of the user performing the action.</param>
    /// <returns>An AuditLog object containing the audit details.</returns>
    public AuditLog CreateAuditLog<T>(T? before, T? after, AuditAction action, string userId)
    {
      // Initialize the audit log with basic information
      var log = new AuditLog
      {
        EntityName = typeof(T).Name,
        Action = action,
        UserId = userId,
        Timestamp = DateTime.UtcNow
      };

      // Handle Updated action: compare before and after, log changed properties
      if (action == AuditAction.Updated && before != null && after != null)
      {
        foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
          var oldValue = prop.GetValue(before);
          var newValue = prop.GetValue(after);

          // Only log properties that have changed
          if (!Equals(oldValue, newValue))
          {
            AuditChange auditChange = new AuditChange
            {
              PropertyName = prop.Name,
              OldValue = oldValue?.ToString(),
              NewValue = newValue?.ToString()
            };
            log.Changes.Add(auditChange);
          }
        }
      }

      // Handle Created action: log all properties as new values
      if (action == AuditAction.Created && after != null)
      {
        foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
          var newValue = prop.GetValue(after);
          AuditChange auditChange = new AuditChange
          {
            PropertyName = prop.Name,
            OldValue = null,
            NewValue = newValue?.ToString()
          };
          log.Changes.Add(auditChange);
        }
      }

      // Handle Deleted action: log all properties as old values
      if (action == AuditAction.Deleted && before != null)
      {
        foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
          var oldValue = prop.GetValue(before);
          AuditChange auditChange = new AuditChange
          {
            PropertyName = prop.Name,
            OldValue = oldValue?.ToString(),
            NewValue = null
          };
          log.Changes.Add(auditChange);
        }
      }

      return log;
    }
  }
}