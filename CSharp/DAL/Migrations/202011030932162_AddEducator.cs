namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEducator : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educators",
                c => new
                    {
                        EducatorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EducatorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Educators");
        }
    }
}
