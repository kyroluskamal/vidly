namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertBirthdatetoDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BirthDate", c => c.String());
            AlterColumn("dbo.Customers", "name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
