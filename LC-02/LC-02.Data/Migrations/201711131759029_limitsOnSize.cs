namespace LC_02.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class limitsOnSize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
        }
    }
}
