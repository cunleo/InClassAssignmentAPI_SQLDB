using CourseAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Data
{
    public class AppsContext: DbContext
    {
        public DbSet<StudentPoco> students { get; set; }
        public DbSet<CoursePoco> courses { get; set; }

        public DbSet<EnrollmentPoco> enrollment { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //   optionsBuilder.UseSqlServer(@"Data Source=localhost\HUMBERBRIDGING;Initial Catalog =JOB_PORTAL_DB;Integrated Security = True; ");

        }

        public AppsContext(DbContextOptions<AppsContext> options)
         : base(options)
        {

        }


    }
}
