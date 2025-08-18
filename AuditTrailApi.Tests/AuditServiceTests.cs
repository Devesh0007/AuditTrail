using AuditTrail.API.Enums;
using AuditTrail.API.Models;
using AuditTrail.API.Services;

namespace AuditTrailApi.Tests
{
  public class AuditServiceTests
  {
    // Create an instance of the AuditService to be used in the tests
    private readonly AuditService _service = new();

    /// <summary>
    /// Test that verifies audit logging for entity creation.
    /// Ensures that the Created action is logged and that property changes are detected.
    /// </summary>
    [Fact]
    public void Should_Log_Created_Entity()
    {
      // Arrange: Only 'after' state is provided for creation
      var after = new Employee { Id = 1, Name = "Alice", Role = "Dev", Salary = 5000 };

      // Act: Create audit log for the created entity
      var log = _service.CreateAuditLog(null, after, AuditAction.Created, "user123");

      // Assert: The action should be 'Created' and changes should include the 'Name' property
      Assert.Equal(AuditAction.Created, log.Action);
      Assert.Contains(log.Changes, x => x.PropertyName == nameof(Employee.Name));
    }

    /// <summary>
    /// Test that verifies audit logging for entity updates.
    /// Ensures that all changed properties are detected and logged.
    /// </summary>
    [Fact]
    public void Should_Log_Updated_Entity()
    {
      // Arrange: Provide 'before' and 'after' states with differences
      var before = new Employee { Id = 1, Name = "Alice", Role = "Dev", Salary = 5000 };
      var after = new Employee { Id = 1, Name = "Alice B", Role = "Lead", Salary = 6000 };

      // Act: Create audit log for the updated entity
      var log = _service.CreateAuditLog(before, after, AuditAction.Updated, "user123");

      // Assert: There should be 3 changes (Name, Role, Salary) and 'Role' should be among them
      Assert.Equal(3, log.Changes.Count); // Name, Role, Salary
      Assert.Contains(nameof(Employee.Role), log.Changes.Select(c => c.PropertyName));
    }

    /// <summary>
    /// Test that verifies audit logging for entity deletion.
    /// Ensures that the Deleted action is logged and that property changes are detected.
    /// </summary>
    [Fact]
    public void Should_Log_Deleted_Entity()
    {
      // Arrange: Only 'before' state is provided for deletion
      var before = new Employee { Id = 1, Name = "Alice", Role = "Dev", Salary = 5000 };

      // Act: Create audit log for the deleted entity
      var log = _service.CreateAuditLog(before, null, AuditAction.Deleted, "user123");

      // Assert: The action should be 'Deleted' and changes should include the 'Name' property
      Assert.Equal(AuditAction.Deleted, log.Action);
      Assert.Contains(nameof(Employee.Name), log.Changes.Select(c => c.PropertyName));
    }
  }
}