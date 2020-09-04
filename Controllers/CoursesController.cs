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
    public class CoursesController : ControllerBase
    {
        private readonly  AppsContext _context;

        public CoursesController(AppsContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoursePoco>>> GetCoursePoco()
        {
            return await _context.courses.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoursePoco>> GetCoursePoco(int id)
        {
            var coursePoco = await _context.courses.FindAsync(id);

            if (coursePoco == null)
            {
                return NotFound();
            }

            return coursePoco;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoursePoco(int id, CoursePoco coursePoco)
        {
            if (id != coursePoco.Id)
            {
                return BadRequest();
            }

            _context.Entry(coursePoco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursePocoExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CoursePoco>> PostCoursePoco(CoursePoco coursePoco)
        {
            _context.courses.Add(coursePoco);
            await _context.SaveChangesAsync();

            //   return CreatedAtAction("GetCoursePoco", new { id = coursePoco.Id }, coursePoco);
            return Ok();
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CoursePoco>> DeleteCoursePoco(int id)
        {
            var coursePoco = await _context.courses.FindAsync(id);
            if (coursePoco == null)
            {
                return NotFound();
            }

            _context.courses.Remove(coursePoco);
            await _context.SaveChangesAsync();

            return coursePoco;
        }

        private bool CoursePocoExists(int id)
        {
            return _context.courses.Any(e => e.Id == id);
        }
    }
}
