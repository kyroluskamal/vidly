﻿namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes set Name = 'Pay as you go' WHERE Id=1");
            Sql("UPDATE MembershipTypes set Name = 'Monthly' WHERE Id=2");
            Sql("UPDATE MembershipTypes set Name = 'Qurterly' WHERE Id=3");
            Sql("UPDATE MembershipTypes set Name = 'Yearly' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
