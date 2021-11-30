namespace Fledgling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WindsTwo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Audiences", new[] { "IdeaId" });
            DropIndex("dbo.Ideas", new[] { "ProjectId" });
            CreateIndex("dbo.Audiences", "IdeaID");
            CreateIndex("dbo.Ideas", "ProjectID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ideas", new[] { "ProjectID" });
            DropIndex("dbo.Audiences", new[] { "IdeaID" });
            CreateIndex("dbo.Ideas", "ProjectId");
            CreateIndex("dbo.Audiences", "IdeaId");
        }
    }
}
