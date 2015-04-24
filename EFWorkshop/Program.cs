using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Edm;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWorkshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new EfWorkshopContext().Database.Initialize(false);

            Console.WriteLine("Enter option");
            var key = Console.ReadKey();
            Console.WriteLine();

            switch (key.Key)
            {
                case ConsoleKey.A:
                    LazyLoading();
                    break;
                case ConsoleKey.B:
                    EagerLoading();
                    break;
                case ConsoleKey.C:
                    var sw = new Stopwatch();
                    sw.Start();
                    ExplicitLoading();
                    sw.Stop();
                    Console.WriteLine(sw.ElapsedMilliseconds);

                    var sw1 = new Stopwatch();
                    sw1.Start();
                    ExplicitLoading();
                    sw1.Stop();
                    Console.WriteLine(sw1.ElapsedMilliseconds);

                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }

        private static void LazyLoading()
        {
            using (var ctx = new EfWorkshopContext())
            {
                var student = ctx.Students
                                 .FirstOrDefault(s => s.Name.Equals("John Doe"));

                Console.WriteLine("Name: " + student.Name);
                Console.WriteLine("Class: " + student.StudentClass.Name);
            }
        }

        private static void EagerLoading()
        {
            using (var ctx = new EfWorkshopContext())
            {
                var student = ctx.Students
                                 .Where(s => s.Name.Equals("John Doe"))
                                 .Include(a => a.StudentClass)
                                 .FirstOrDefault();

                Console.WriteLine("Name: " + student.Name);
                Console.WriteLine("Class: " + student.StudentClass.Name);
            }
        }

        private static void ExplicitLoading()
        {
            using (var ctx = new EfWorkshopContext())
            {
                var student = ctx.Students
                                .Where(s => s.Name.Equals("John Doe"))
                                .Select(s => new
                                {
                                    StudentName = s.Name,
                                    ClassName = s.StudentClass.Name
                                })
                                .FirstOrDefault();

                Console.WriteLine("Name: " + student.StudentName);
                Console.WriteLine("Class: " + student.ClassName);
            }
        }
    }
}
