namespace EFWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentCourseMap",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.CourseId })
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourseMap", "CourseId", "dbo.Course");
            DropForeignKey("dbo.StudentCourseMap", "StudentId", "dbo.Student");
            DropIndex("dbo.StudentCourseMap", new[] { "CourseId" });
            DropIndex("dbo.StudentCourseMap", new[] { "StudentId" });
            DropTable("dbo.StudentCourseMap");
            DropTable("dbo.Course");
        }
    }
}
