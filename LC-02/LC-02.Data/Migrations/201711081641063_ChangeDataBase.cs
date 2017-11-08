namespace LC_02.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        Content = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventType = c.Int(nullable: false),
                        EventCategoryName = c.Int(nullable: false),
                        PlaceCategoryName = c.String(),
                        Title = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        ImagePath = c.String(),
                        Description = c.String(),
                        Rank = c.Single(nullable: false),
                        OrganizerId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        StartEventDate = c.DateTime(nullable: false),
                        EndEventDate = c.DateTime(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        HistoryId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserType = c.Int(nullable: false),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        PhoneNumber = c.String(),
                        Rank = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "EventId", "dbo.Events");
            DropIndex("dbo.Events", new[] { "User_UserId" });
            DropIndex("dbo.Comments", new[] { "EventId" });
            DropTable("dbo.Users");
            DropTable("dbo.Histories");
            DropTable("dbo.Events");
            DropTable("dbo.Comments");
        }
    }
}
