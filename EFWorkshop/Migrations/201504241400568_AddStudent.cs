namespace EFWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "UX_Student_Name");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Student", "UX_Student_Name");
            DropTable("dbo.Student");
        }
    }
}
