namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert MembershipTypes ON");
            Sql("insert into dbo.MembershipTypes(Id, Name, SignUpFee, DurationInMonths, DiscountRate) values(1, 'PAYG', 0, 0, 0)");
            Sql("insert into dbo.MembershipTypes(Id, Name, SignUpFee, DurationInMonths, DiscountRate) values(2, 'Monthly', 50, 1, 5)");

        }

        public override void Down()
        {
        }
    }
}
