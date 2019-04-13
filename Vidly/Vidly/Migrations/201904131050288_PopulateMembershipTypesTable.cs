namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert MembershipTypes on ");
            Sql("Insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) values(1,0,0,0)");
        }
        
        public override void Down()
        {
        }
    }
}
