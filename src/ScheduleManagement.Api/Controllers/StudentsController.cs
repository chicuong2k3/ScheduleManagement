using Microsoft.AspNetCore.Mvc;
using ScheduleManagement.Api.Models;

namespace ScheduleManagement.Api.Controllers;

// request: header, body
// query string
// response

// Code First 
// Database First

// add model validation
[ApiController] // Attribute 
[Route("api/[controller]")] // api/students
public class StudentsController : ControllerBase
{
    // GET, POST, PUT, DELETE
    [HttpGet] // action method
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents(
        CancellationToken cancellationToken)
    {
        
        return Ok(); // 200 OK
    }

    // GET: api/students/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Student>> GetStudent(
        int id,
        CancellationToken cancellationToken)
    {
        return Ok();
    }
}