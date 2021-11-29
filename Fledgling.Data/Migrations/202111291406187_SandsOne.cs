namespace Fledgling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SandsOne : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visitors", "CreatedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Visitors", "ModifiedUTC", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Visitors", "ModifiedUTC");
            DropColumn("dbo.Visitors", "CreatedUTC");
        }
    }
}
