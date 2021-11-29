namespace Fledgling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SandsThree : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "VisitorID", "dbo.Visitors");
            DropIndex("dbo.Projects", new[] { "VisitorID" });
            RenameColumn(table: "dbo.Projects", name: "VisitorID", newName: "Visitor_VisitorID");
            AlterColumn("dbo.Projects", "Visitor_VisitorID", c => c.Int());
            CreateIndex("dbo.Projects", "Visitor_VisitorID");
            AddForeignKey("dbo.Projects", "Visitor_VisitorID", "dbo.Visitors", "VisitorID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Visitor_VisitorID", "dbo.Visitors");
            DropIndex("dbo.Projects", new[] { "Visitor_VisitorID" });
            AlterColumn("dbo.Projects", "Visitor_VisitorID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Projects", name: "Visitor_VisitorID", newName: "VisitorID");
            CreateIndex("dbo.Projects", "VisitorID");
            AddForeignKey("dbo.Projects", "VisitorID", "dbo.Visitors", "VisitorID", cascadeDelete: true);
        }
    }
}
