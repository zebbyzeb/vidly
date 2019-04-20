namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert Movies on ");
            Sql("insert into movies (Id, Name, ReleaseDate, DateAdded, AvailableStock, GenreId) " +
                "values (1, 'The Godfather', '01/01/1971', '20/04/2019', 20, 2)");
            Sql("insert into movies (Id, Name, ReleaseDate, DateAdded, AvailableStock, GenreId) " +
                "values (2, 'The Hangover', '01/01/2011', '20/04/2019', 10, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
