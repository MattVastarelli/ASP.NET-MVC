namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Names : DbMigration
    {
        public override void Up()
        {
            Sql("update membershiptypes set membershipname='Pay as you go' where id=1");
            Sql("update membershiptypes set membershipname='Monthly' where id=2");
            Sql("update membershiptypes set membershipname='Quarterly' where id=3");
            Sql("update membershiptypes set membershipname='Annual' where id=4");
        }
        
        public override void Down()
        {
        }
    }
}
