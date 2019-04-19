namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBirthdateColumnInCustomersTable : DbMigration
    {
        public override void Up()
        {
            Sql("update customers set birthdate='24/08/1993' where Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
