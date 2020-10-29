namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genere : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Genre_id", c => c.Int());
            CreateIndex("dbo.Movies", "Genre_id");
            AddForeignKey("dbo.Movies", "Genre_id", "dbo.Genres", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_id" });
            DropColumn("dbo.Movies", "Genre_id");
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
