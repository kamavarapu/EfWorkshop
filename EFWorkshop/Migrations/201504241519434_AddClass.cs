namespace EFWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Student", "StudentClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.Student", "StudentClassId");
            AddForeignKey("dbo.Student", "StudentClassId", "dbo.StudentClass", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "StudentClassId", "dbo.StudentClass");
            DropIndex("dbo.Student", new[] { "StudentClassId" });
            DropColumn("dbo.Student", "StudentClassId");
            DropTable("dbo.StudentClass");
        }
    }
}
