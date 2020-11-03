namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecializationToEducator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Educators", "Specialization", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Educators", "Specialization");
        }
    }
}
