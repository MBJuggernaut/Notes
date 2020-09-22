namespace NotesWindowsFormsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskDates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Time = c.String(nullable: false, maxLength: 5),
                        AlarmTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Text = c.String(nullable: false, maxLength: 50),
                        Repeating = c.String(nullable: false, maxLength: 15),
                        Alarming = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskTaskDates",
                c => new
                    {
                        Task_Id = c.Int(nullable: false),
                        TaskDate_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Task_Id, t.TaskDate_Id })
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .ForeignKey("dbo.TaskDates", t => t.TaskDate_Id, cascadeDelete: true)
                .Index(t => t.Task_Id)
                .Index(t => t.TaskDate_Id);
            
            CreateTable(
                "dbo.TagTasks",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Task_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Task_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Task_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagTasks", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.TagTasks", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TaskTaskDates", "TaskDate_Id", "dbo.TaskDates");
            DropForeignKey("dbo.TaskTaskDates", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.TagTasks", new[] { "Task_Id" });
            DropIndex("dbo.TagTasks", new[] { "Tag_Id" });
            DropIndex("dbo.TaskTaskDates", new[] { "TaskDate_Id" });
            DropIndex("dbo.TaskTaskDates", new[] { "Task_Id" });
            DropTable("dbo.TagTasks");
            DropTable("dbo.TaskTaskDates");
            DropTable("dbo.Tags");
            DropTable("dbo.Tasks");
            DropTable("dbo.TaskDates");
        }
    }
}
