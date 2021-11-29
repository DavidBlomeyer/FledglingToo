namespace Fledgling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ideas",
                c => new
                    {
                        IdeaID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        MemberId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        IdeaName = c.String(),
                        IdeaAuthor = c.String(),
                        IdeaThesis = c.String(),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.IdeaID)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: false)
                .ForeignKey("dbo.Visitors", t => t.MemberId, cascadeDelete: false)
                .Index(t => t.MemberId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        MemberId = c.Int(nullable: false),
                        ProjectName = c.String(),
                        ProjectAuthor = c.String(),
                        ProjectThesis = c.String(),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Visitors", t => t.MemberId, cascadeDelete: false)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Requirements",
                c => new
                    {
                        RequirementID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        MemberId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Goal = c.String(),
                        SourceHeaderOne = c.String(),
                        SourceBodyOne = c.String(),
                        SourceHeaderTwo = c.String(),
                        SourceBodyTwo = c.String(),
                        SourceHeaderThree = c.String(),
                        SourceBodyThree = c.String(),
                        SourceHeaderFour = c.String(),
                        SourceBodyFour = c.String(),
                        SourceHeaderFive = c.String(),
                        SourceBodyFive = c.String(),
                        SourceHeaderSix = c.String(),
                        SourceBodySix = c.String(),
                        LinkHeaderOne = c.String(),
                        LinkBodyOne = c.String(),
                        LinkHeaderTwo = c.String(),
                        LinkBodyTwo = c.String(),
                        LinkHeaderThree = c.String(),
                        LinkBodyThree = c.String(),
                        LinkHeaderFour = c.String(),
                        LinkBodyFour = c.String(),
                        LinkHeaderFive = c.String(),
                        LinkBodyFive = c.String(),
                        LinkHeaderSix = c.String(),
                        LinkBodySix = c.String(),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.RequirementID)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: false)
                .ForeignKey("dbo.Visitors", t => t.MemberId, cascadeDelete: false)
                .Index(t => t.MemberId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        VisitorID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.VisitorID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Ideas", "MemberId", "dbo.Visitors");
            DropForeignKey("dbo.Ideas", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "MemberId", "dbo.Visitors");
            DropForeignKey("dbo.Requirements", "MemberId", "dbo.Visitors");
            DropForeignKey("dbo.Requirements", "ProjectId", "dbo.Projects");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Requirements", new[] { "ProjectId" });
            DropIndex("dbo.Requirements", new[] { "MemberId" });
            DropIndex("dbo.Projects", new[] { "MemberId" });
            DropIndex("dbo.Ideas", new[] { "ProjectId" });
            DropIndex("dbo.Ideas", new[] { "MemberId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Visitors");
            DropTable("dbo.Requirements");
            DropTable("dbo.Projects");
            DropTable("dbo.Ideas");
        }
    }
}
