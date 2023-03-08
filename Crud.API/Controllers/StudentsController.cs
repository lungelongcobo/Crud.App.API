using Crud.API.DataAccess;
using Crud.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly CrudDbContext _crudDbContext;

        public StudentsController(CrudDbContext crudDbContext)
        {
            _crudDbContext = crudDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _crudDbContext.Students.ToListAsync();

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student studentRequest)
        {
           studentRequest.Id = Guid.NewGuid();

           await _crudDbContext.Students.AddAsync(studentRequest);
           await _crudDbContext.SaveChangesAsync();

           return Ok(studentRequest);
        }
    }
}
