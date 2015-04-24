using EFWorkshop.Domain;

namespace EFWorkshop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFWorkshop.EfWorkshopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFWorkshop.EfWorkshopContext context)
        {
            var firstGrade = new StudentClass
            {
                Id = 1,
                Name = "First Grade"
            };
            context.StudentClasses.AddOrUpdate(firstGrade);

            var firstStudent = new Student
            {
                Id = 1,
                Name = "John Doe",
                Address = new Address
                {
                    City = "Pittsburgh",
                    State = "PA",
                    StudentId = 1
                },
                StudentClassId = firstGrade.Id,
                StudentClass = firstGrade
            };

            context.Students.AddOrUpdate(firstStudent);

            var math = new Course
            {
                Id = 1,
                Name = "Mathematics"
            };
            
            if (math.Students.FirstOrDefault(s => s.Id == firstStudent.Id) == null)
                math.Students.Add(firstStudent);
            
            context.Courses.AddOrUpdate(math);
        }
    }
}
