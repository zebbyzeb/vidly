namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert Genres on");
            Sql("insert into Genres(Id, Name) values(1, 'Comedy')");
            Sql("insert into Genres(Id, Name) values(2, 'Drama')");
            Sql("insert into Genres(Id, Name) values(3, 'Action')");
            Sql("insert into Genres(Id, Name) values(4, 'Horror')");
        }

        public override void Down()
        {
        }
    }
}
