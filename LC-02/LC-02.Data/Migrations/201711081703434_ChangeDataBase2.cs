namespace LC_02.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataBase2 : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Comments DROP CONSTRAINT DF__Comments__Commen__47DBAE45");
            AlterColumn("dbo.Comments", "CommentContent", c => c.String());
            AlterColumn("dbo.Users", "Rank", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Rank", c => c.Single(nullable: false));
            AlterColumn("dbo.Comments", "CommentContent", c => c.Int(nullable: false));
        }
    }
}
