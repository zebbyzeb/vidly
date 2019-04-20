namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert Genres on ");

            Sql("insert into genres (Id, Name) values (1, 'Comedy')");
            Sql("insert into genres (Id, Name) values (2, 'Drama')");
            Sql("insert into genres (Id, Name) values (3, 'Horror')");
            Sql("insert into genres (Id, Name) values (4, 'Action')");
        }
        
        public override void Down()
        {
        }
    }
}
