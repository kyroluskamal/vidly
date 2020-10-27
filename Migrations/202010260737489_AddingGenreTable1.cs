namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGenreTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GenreId = c.Byte(nullable: false),
                        genre_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.genre_id)
                .Index(t => t.genre_id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genre_id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_id" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
    }
}
