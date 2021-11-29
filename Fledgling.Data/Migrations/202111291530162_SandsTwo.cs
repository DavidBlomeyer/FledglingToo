namespace Fledgling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SandsTwo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Ideas", name: "MemberId", newName: "VisitorID");
            RenameColumn(table: "dbo.Projects", name: "MemberId", newName: "VisitorID");
            RenameColumn(table: "dbo.Requirements", name: "MemberId", newName: "VisitorID");
            RenameIndex(table: "dbo.Ideas", name: "IX_MemberId", newName: "IX_VisitorID");
            RenameIndex(table: "dbo.Projects", name: "IX_MemberId", newName: "IX_VisitorID");
            RenameIndex(table: "dbo.Requirements", name: "IX_MemberId", newName: "IX_VisitorID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Requirements", name: "IX_VisitorID", newName: "IX_MemberId");
            RenameIndex(table: "dbo.Projects", name: "IX_VisitorID", newName: "IX_MemberId");
            RenameIndex(table: "dbo.Ideas", name: "IX_VisitorID", newName: "IX_MemberId");
            RenameColumn(table: "dbo.Requirements", name: "VisitorID", newName: "MemberId");
            RenameColumn(table: "dbo.Projects", name: "VisitorID", newName: "MemberId");
            RenameColumn(table: "dbo.Ideas", name: "VisitorID", newName: "MemberId");
        }
    }
}
