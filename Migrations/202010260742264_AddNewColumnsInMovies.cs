namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewColumnsInMovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "genre_id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_id" });
            AddColumn("dbo.Movies", "ReleaseDate", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Movies", "DateAdded", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Movies", "numberInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "genre_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "genre_id");
            AddForeignKey("dbo.Movies", "genre_id", "dbo.Genres", "id", cascadeDelete: true);
            DropColumn("dbo.Movies", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Movies", "genre_id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_id" });
            AlterColumn("dbo.Movies", "genre_id", c => c.Int());
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "numberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            CreateIndex("dbo.Movies", "genre_id");
            AddForeignKey("dbo.Movies", "genre_id", "dbo.Genres", "id");
        }
    }
}
