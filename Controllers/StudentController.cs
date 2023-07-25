// Controllers/StudentController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
  private readonly MongoDbContext _context;

  public StudentController(IConfiguration configuration)
  {
    _context = new MongoDbContext(configuration);
  }

  [HttpGet]
  public ActionResult<IEnumerable<Student>> GetStudents([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
  {
    var totalStudents = _context.Students.CountDocuments(_ => true);
    var totalPages = (int)(totalStudents / pageSize) + ((totalStudents % pageSize) > 0 ? 1 : 0);

    var students = _context.Students
        .Find(_ => true)
        .Skip((page - 1) * pageSize)
        .Limit(pageSize)
        .ToList();

    return Ok(new
    {
      TotalStudents = totalStudents,
      TotalPages = totalPages,
      CurrentPage = page,
      PageSize = pageSize,
      Students = students
    });
  }
}
