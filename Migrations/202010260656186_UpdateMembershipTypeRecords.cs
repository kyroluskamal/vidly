namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeRecords : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes set Name = 'Pay as you go' WHERE SiqgnUpFee=0");
            Sql("UPDATE MembershipTypes set Name = 'Monthly' WHERE SiqgnUpFee=30");
            Sql("UPDATE MembershipTypes set Name = 'Qurterly' WHERE SiqgnUpFee=90");
            Sql("UPDATE MembershipTypes set Name = 'Yearly' WHERE SiqgnUpFee=300");
        }
        
        public override void Down()
        {
        }
    }
}
