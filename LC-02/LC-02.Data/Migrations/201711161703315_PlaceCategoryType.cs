namespace LC_02.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlaceCategoryType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "PlaceCategoryName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "PlaceCategoryName", c => c.String());
        }
    }
}
