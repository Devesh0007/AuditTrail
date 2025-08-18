using AuditTrail.API.Models;
using AuditTrail.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuditTrailApi.Controllers
{
  // Indicates that this controller responds to web API requests
  [ApiController]
  // Sets the base route for all actions in this controller to "api/audit"
  [Route("api/[controller]")]
  public class AuditController : ControllerBase
  {
    // Service for handling audit log operations
    private readonly IAuditService _auditService;

    // Constructor with dependency injection for the audit service
    public AuditController(IAuditService auditService)
    {
      _auditService = auditService;
    }

    // Handles HTTP POST requests to "api/audit/log" for logging changes
    [HttpPost("log")]
    public IActionResult LogChange([FromBody] AuditRequest<Employee> request)
    {
      // Create an audit log entry using the provided request data
      var auditLog = _auditService.CreateAuditLog(
          request.Before,
          request.After,
          request.Action,
          request.UserId
      );
      // Return the created audit log entry as the response
      return Ok(auditLog);
    }
  }
}
