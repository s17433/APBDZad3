using GakkoHorizontalSlice.Model;
using GakkoHorizontalSlice.Services;
using Microsoft.AspNetCore.Mvc;

namespace GakkoHorizontalSlice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private IStudentsService _studentsService;
    
    public StudentsController(IStudentsService studentsService)
    {
        _studentsService = studentsService;
    }
    
    /// <summary>
    /// Endpoints used to return list of students.
    /// </summary>
    /// <returns>List of students</returns>
    [HttpGet]
    public IActionResult GetStudents()
    {
        var students = _studentsService.GetStudents();
        return Ok(students);
    }
    
    /// <summary>
    /// Endpoint used to return a single student.
    /// </summary>
    /// <param name="id">Id of a student</param>
    /// <returns>Student</returns>
    [HttpGet("{id:int}")]
    public IActionResult GetStudent(int id)
    {
        var student = _studentsService.GetStudent(id);

        if (student==null)
        {
            return NotFound("Student not found");
        }
        
        return Ok(student);
    }
    
    /// <summary>
    /// Endpoint used to create a student.
    /// </summary>
    /// <param name="student">New student data</param>
    /// <returns>201 Created</returns>
    [HttpPost]
    public IActionResult CreateStudent(Student student)
    {
        var affectedCount = _studentsService.CreateStudent(student);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    /// <summary>
    /// Endpoint used to update a student.
    /// </summary>
    /// <param name="id">Id of a student</param>
    /// <param name="student">204 No Content</param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public IActionResult UpdateStudent(int id, Student student)
    {
        var affectedCount = _studentsService.UpdateStudent(student);
        return NoContent();
    }
    
    /// <summary>
    /// Endpoint used to delete a student.
    /// </summary>
    /// <param name="id">Id of a student</param>
    /// <returns>204 No Content</returns>
    [HttpDelete("{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        var affectedCount = _studentsService.DeleteStudent(id);
        return NoContent();
    }
}