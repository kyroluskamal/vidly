namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genere2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
