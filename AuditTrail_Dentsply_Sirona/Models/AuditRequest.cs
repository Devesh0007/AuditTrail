using AuditTrail.API.Enums;

namespace AuditTrail.API.Models
{
  /// <summary>
  /// Represents an audit request containing the state before and after an action, the action performed, and the user who performed it.
  /// </summary>
  /// <typeparam name="T">The type of the entity being audited.</typeparam>
  public class AuditRequest<T>
  {
    /// <summary>
    /// The state of the entity before the action was performed.
    /// </summary>
    public T? Before { get; set; }

    /// <summary>
    /// The state of the entity after the action was performed.
    /// </summary>
    public T? After { get; set; }

    /// <summary>
    /// The type of action performed (Created, Updated, Deleted).
    /// </summary>
    public AuditAction Action { get; set; }

    /// <summary>
    /// The identifier of the user who performed the action.
    /// </summary>
    public string UserId { get; set; } = string.Empty;
  }
}
