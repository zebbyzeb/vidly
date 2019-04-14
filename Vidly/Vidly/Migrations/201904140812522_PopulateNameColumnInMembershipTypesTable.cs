namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameColumnInMembershipTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name = 'PAYG' where Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
