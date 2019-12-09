namespace Kiem_Tra_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addExam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ExamSubjectid = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false, precision: 0),
                        ExamDate = c.DateTime(nullable: false, precision: 0),
                        Duration = c.Int(nullable: false),
                        ClassRoomid = c.Int(nullable: false),
                        Facultyid = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoomid, cascadeDelete: true)
                .ForeignKey("dbo.ExamSubjects", t => t.ExamSubjectid, cascadeDelete: true)
                .ForeignKey("dbo.Faculties", t => t.Facultyid, cascadeDelete: true)
                .Index(t => t.ExamSubjectid)
                .Index(t => t.ClassRoomid)
                .Index(t => t.Facultyid);
            
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ClassNAme = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ExamSubjects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FacultiName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "Facultyid", "dbo.Faculties");
            DropForeignKey("dbo.Exams", "ExamSubjectid", "dbo.ExamSubjects");
            DropForeignKey("dbo.Exams", "ClassRoomid", "dbo.ClassRooms");
            DropIndex("dbo.Exams", new[] { "Facultyid" });
            DropIndex("dbo.Exams", new[] { "ClassRoomid" });
            DropIndex("dbo.Exams", new[] { "ExamSubjectid" });
            DropTable("dbo.Faculties");
            DropTable("dbo.ExamSubjects");
            DropTable("dbo.ClassRooms");
            DropTable("dbo.Exams");
        }
    }
}
