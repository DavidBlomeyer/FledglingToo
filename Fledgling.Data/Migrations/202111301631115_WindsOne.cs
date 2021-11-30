namespace Fledgling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WindsOne : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Requirements", new[] { "ProjectId" });
            CreateIndex("dbo.Requirements", "ProjectID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Requirements", new[] { "ProjectID" });
            CreateIndex("dbo.Requirements", "ProjectId");
        }
    }
}
