// Ignore Spelling: Timestamp

using AuditTrail.API.Enums;

namespace AuditTrail.Models
{
  /// <summary>
  /// Represents an audit log entry for tracking changes to an entity.
  /// </summary>
  public sealed class AuditLog
  {
    /// <summary>
    /// Gets or sets the name of the entity being audited.
    /// </summary>
    public string EntityName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the action performed on the entity.
    /// </summary>
    public AuditAction Action { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who performed the action.
    /// </summary>
    public string UserId { get; set; } = default!;

    /// <summary>
    /// Gets or sets the timestamp when the action occurred (in UTC).
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the list of changes made to the entity.
    /// </summary>
    public List<AuditChange> Changes { get; set; } = new();
  }

  /// <summary>
  /// Represents a change to a single property of an entity.
  /// </summary>
  public sealed class AuditChange
  {
    /// <summary>
    /// Gets or sets the name of the property that was changed.
    /// </summary>
    public string PropertyName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the old value of the property.
    /// </summary>
    public string? OldValue { get; set; }

    /// <summary>
    /// Gets or sets the new value of the property.
    /// </summary>
    public string? NewValue { get; set; }
  }
}
