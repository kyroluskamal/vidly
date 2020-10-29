namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class convertToDate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "name", c => c.String(maxLength: 255));
        }
    }
}
