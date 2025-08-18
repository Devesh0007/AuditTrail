using AuditTrail.API.Enums;
using AuditTrail.Models;

namespace AuditTrail.API.Services.Interfaces
{
  public interface IAuditService
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
    AuditLog CreateAuditLog<T>(T? before, T? after, AuditAction action, string userId);
  }
}