namespace NotesWindowsFormsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullablenote : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "Text", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "Text", c => c.String(nullable: false));
        }
    }
}
