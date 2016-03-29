namespace FcuMVCPorject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentProfile",
                c => new
                    {
                        guid = c.Guid(nullable: false),
                        Id = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Tel = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentProfile");
        }
    }
}
