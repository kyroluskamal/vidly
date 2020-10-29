namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genere1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_id" });
            DropColumn("dbo.Movies", "Genre_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre_id", c => c.Int());
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "Genre_id");
            AddForeignKey("dbo.Movies", "Genre_id", "dbo.Genres", "id");
        }
    }
}
