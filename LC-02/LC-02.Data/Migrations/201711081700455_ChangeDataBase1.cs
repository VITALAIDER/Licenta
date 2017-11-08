namespace LC_02.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataBase1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "User_UserId", "dbo.Users");
            DropIndex("dbo.Events", new[] { "User_UserId" });
            RenameColumn(table: "dbo.Events", name: "User_UserId", newName: "UserId");
            AddColumn("dbo.Comments", "CommentContent", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "Rank", c => c.Single());
            AlterColumn("dbo.Events", "StartEventDate", c => c.DateTime());
            AlterColumn("dbo.Events", "EndEventDate", c => c.DateTime());
            AlterColumn("dbo.Events", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "UserId");
            AddForeignKey("dbo.Events", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            DropColumn("dbo.Comments", "Content");
            DropColumn("dbo.Events", "OrganizerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "OrganizerId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Content", c => c.Int(nullable: false));
            DropForeignKey("dbo.Events", "UserId", "dbo.Users");
            DropIndex("dbo.Events", new[] { "UserId" });
            AlterColumn("dbo.Events", "UserId", c => c.Int());
            AlterColumn("dbo.Events", "EndEventDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "StartEventDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Rank", c => c.Single(nullable: false));
            DropColumn("dbo.Comments", "CommentContent");
            RenameColumn(table: "dbo.Events", name: "UserId", newName: "User_UserId");
            CreateIndex("dbo.Events", "User_UserId");
            AddForeignKey("dbo.Events", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
