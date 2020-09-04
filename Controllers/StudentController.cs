using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseAPI.Data;
using CourseAPI.Model;

namespace CourseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppsContext _context;

        public StudentController(AppsContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentPoco>>> Getstudents()
        {
            return await _context.students.ToListAsync();
        }

      
        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentPoco>> GetStudentPoco(int id)
        {
            var studentPoco = await _context.students.FindAsync(id);

            if (studentPoco == null)
            {
                return NotFound();
            }

            return studentPoco;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentPoco(int id, StudentPoco studentPoco)
        {
            if (id != studentPoco.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentPoco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.students.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Student
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentPoco>> PostStudentPoco(StudentPoco studentPoco)
        {
            _context.students.Add(studentPoco);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetStudentPoco", new { id = studentPoco.Id }, studentPoco);
            return Ok();
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentPoco>> DeleteStudentPoco(int id)
        {
            var studentPoco = await _context.students.FindAsync(id);
            if (studentPoco == null)
            {
                return NotFound();
            }

            _context.students.Remove(studentPoco);
            await _context.SaveChangesAsync();

            return studentPoco;
        }

        //private bool StudentPocoExists(int id)
        //{
        //    return _context.students.Any(e => e.Id == id);
        //}
    }
}
