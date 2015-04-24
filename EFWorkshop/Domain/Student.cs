using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWorkshop.Domain
{
    public class Student
    {
        public Student()
        {
            Courses = new List<Course>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Address Address { get; set; }

        public int StudentClassId { get; set; }

        public virtual StudentClass StudentClass { get; set; }

        public virtual ICollection<Course> Courses { get; set; } 
    }
}
