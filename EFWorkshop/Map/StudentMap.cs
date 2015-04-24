using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWorkshop.Domain;

namespace EFWorkshop.Map
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("UX_Student_Name") { IsUnique = true}));

            this.HasOptional(o => o.Address)
                .WithRequired(r => r.Student);

            this.HasRequired(r => r.StudentClass)
                .WithMany(m => m.Students)
                .HasForeignKey(f => f.StudentClassId)
                .WillCascadeOnDelete(false);

            this.HasMany(m => m.Courses)
                .WithMany(s => s.Students)
                .Map(cs =>
                    {
                        cs.MapLeftKey("StudentId");
                        cs.MapRightKey("CourseId");
                        cs.ToTable("StudentCourseMap");
                    }
                );
        }
    }
}
