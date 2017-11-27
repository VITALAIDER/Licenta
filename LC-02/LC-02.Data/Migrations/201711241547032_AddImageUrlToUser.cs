namespace LC_02.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ImageUrl");
        }
    }
}
