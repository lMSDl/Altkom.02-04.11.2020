namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentAndClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        Educator_EducatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Educators", t => t.Educator_EducatorId, cascadeDelete: true)
                .Index(t => t.Educator_EducatorId);
            
            CreateTable(
                "dbo.ClassStudents",
                c => new
                    {
                        Class_ClassId = c.Int(nullable: false),
                        Student_StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Class_ClassId, t.Student_StudentId })
                .ForeignKey("dbo.Classes", t => t.Class_ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .Index(t => t.Class_ClassId)
                .Index(t => t.Student_StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassStudents", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.ClassStudents", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "Educator_EducatorId", "dbo.Educators");
            DropIndex("dbo.ClassStudents", new[] { "Student_StudentId" });
            DropIndex("dbo.ClassStudents", new[] { "Class_ClassId" });
            DropIndex("dbo.Classes", new[] { "Educator_EducatorId" });
            DropTable("dbo.ClassStudents");
            DropTable("dbo.Classes");
            DropTable("dbo.Students");
        }
    }
}
