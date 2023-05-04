namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registerform : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ImePrezime", c => c.String());
            AddColumn("dbo.AspNetUsers", "Opstina", c => c.String());
            AddColumn("dbo.AspNetUsers", "TelBroj", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TelBroj");
            DropColumn("dbo.AspNetUsers", "Opstina");
            DropColumn("dbo.AspNetUsers", "ImePrezime");
        }
    }
}
