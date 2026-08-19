using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleManagement.Api.Data;
using ScheduleManagement.Api.Models;
using ScheduleManagement.Api.Requests;

namespace ScheduleManagement.Api.Controllers;

// RESTful API conventions


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
    private readonly AppDbContext _dbContext;

    public StudentsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET, POST, PUT, DELETE
    [HttpGet] // action method
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents(
        CancellationToken cancellationToken)
    {
        var students = await _dbContext.Students.ToListAsync(cancellationToken);
        return Ok(students); // 200 OK
    }

    // GET: api/students/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Student>> GetStudent(
        int id,
        CancellationToken cancellationToken)
    {
        var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        if (student == null)
        {
            return NotFound(); // 404 Not Found
        }
        return Ok(student); // 200 OK
    }

    // resource
    // POST: api/students
    [HttpPost] // await async
    public async Task<ActionResult<Student>> CreateStudent(
        CreateStudentRequest request,
        CancellationToken cancellationToken)
    {
        // DTO: Data Transfer Object
        // LINQ: Language Integrated Query
        var student = new Student
        {
            Name = request.Name,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth
        };

        _dbContext.Students.Add(student);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var createdStudent = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == student.Id, cancellationToken);

        return Ok(createdStudent);
    }
}