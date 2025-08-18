namespace AuditTrail.API.Models
{
  /// <summary>
  /// Represents an employee in the system.
  /// </summary>
  public class Employee
  {
    /// <summary>
    /// Gets or sets the unique identifier for the employee.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the employee.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the role of the employee.
    /// </summary>
    public string Role { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the salary of the employee.
    /// </summary>
    public decimal Salary { get; set; }
  }
}