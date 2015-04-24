using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFWorkshop.Domain;
using EFWorkshop.Map;

namespace EFWorkshop
{
    [DbConfigurationType(typeof(WorkshopConfiguration))]
    public class EfWorkshopContext : DbContext
    {
        public EfWorkshopContext()
            : base("EfWorkshopContext")
        {
            Database.SetInitializer(new NullDatabaseInitializer<EfWorkshopContext>());
            //Database.Log = Console.WriteLine;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Course> Courses { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
