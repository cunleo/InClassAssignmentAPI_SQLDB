using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Model
{
    public class EnrollmentPoco
    {
        [Key]
        public int EnrollmentId { get; set; }

        [ForeignKey("Id")]
        public int StudentID { get; set; }
        [ForeignKey("Id")] 
        public int CourseID { get; set; }

    }
}
