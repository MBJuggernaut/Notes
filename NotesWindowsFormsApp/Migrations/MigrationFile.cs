namespace NotesWindowsFormsApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable:false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(nullable: false, maxLength: 5),
                        Text = c.String(nullable: false, maxLength: 50),
                        IsActual = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskTags",
                c => new
                    {
                        Task_Id = c.Int(nullable: false),
                        Tags_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Task_Id, t.Tags_Id })
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tags_Id, cascadeDelete: true)
                .Index(t => t.Task_Id)
                .Index(t => t.Tags_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskTags", "Tags_Id", "dbo.Tags");
            DropForeignKey("dbo.TaskTags", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.TaskTags", new[] { "Tags_Id" });
            DropIndex("dbo.TaskTags", new[] { "Task_Id" });
            DropTable("dbo.TaskTags");
            DropTable("dbo.Tasks");
            DropTable("dbo.Tags");
        }
    }
}
