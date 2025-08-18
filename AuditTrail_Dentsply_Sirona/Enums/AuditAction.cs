namespace AuditTrail.API.Enums
{
  /// <summary>
  /// Represents the type of action performed for audit trail purposes.
  /// </summary>
  public enum AuditAction
  {
    /// <summary>
    /// Indicates that an entity was created.
    /// </summary>
    Created,

    /// <summary>
    /// Indicates that an entity was updated.
    /// </summary>
    Updated,

    /// <summary>
    /// Indicates that an entity was deleted.
    /// </summary>
    Deleted
  }
}