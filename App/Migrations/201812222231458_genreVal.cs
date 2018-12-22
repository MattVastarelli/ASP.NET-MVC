namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genreVal : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genres(id, genreName) values(1, 'Comedy')");
            Sql("insert into genres(id, genreName) values(2, 'Action')");
            Sql("insert into genres(id, genreName) values(3, 'Family')");
            Sql("insert into genres(id, genreName) values(4, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
