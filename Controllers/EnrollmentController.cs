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
    public class EnrollmentController : ControllerBase
    {
        private readonly AppsContext _context;

        public EnrollmentController(AppsContext context)
        {
            _context = context;
        }

        // GET: api/Enrollment
        [HttpGet]
        public IActionResult Getenrollment()
        {
            return (IActionResult)_context.enrollment.ToList();
        }

        // GET: api/Enrollment/5
        [HttpGet("{id}")]
        public IActionResult GetEnrollmentPoco(int id)
        {
            var enrollmentPoco =  _context.enrollment.Find(id);

            if (enrollmentPoco == null)
            {
                return NotFound();
            }
            return Ok(enrollmentPoco);
        }

        // PUT: api/Enrollment/5
        [HttpPut("{id}")]
        public IActionResult PutEnrollmentPoco(int id, EnrollmentPoco enrollmentPoco)
        {
            if (id != enrollmentPoco.EnrollmentId)
            {
                return BadRequest();
            }
            _context.Entry(enrollmentPoco).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentPocoExists(id))
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

        // POST: api/Enrollment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostEnrollmentPoco(EnrollmentPoco enrollmentPoco)
        {
            _context.enrollment.Add(enrollmentPoco);
             _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Enrollment/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollmentPoco(int id )

        {
            var enrollmentPoco = _context.enrollment.Find(id);
            if (enrollmentPoco == null)
            {
                return NotFound();
            }

            _context.enrollment.Remove(enrollmentPoco);
             _context.SaveChangesAsync();

            return Ok(); //   return enrollmentPoco;
        }
        private bool EnrollmentPocoExists(int id)
        {
            return _context.enrollment.Any(e => e.EnrollmentId == id);
        }
    }
}
