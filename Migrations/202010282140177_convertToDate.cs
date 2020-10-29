namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class convertToDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
