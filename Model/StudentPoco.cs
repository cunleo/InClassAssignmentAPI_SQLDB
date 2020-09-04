using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace CourseAPI.Model
{
    public class StudentPoco
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }

    }
}
