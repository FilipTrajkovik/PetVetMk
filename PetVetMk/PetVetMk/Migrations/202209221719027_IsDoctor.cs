namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsDoctor", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AmbulantaId", c => c.Int(nullable: false));
            AlterColumn("dbo.VeterinarenDoktors", "DoktorTelBroj", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Role", c => c.String());
            AlterColumn("dbo.VeterinarenDoktors", "DoktorTelBroj", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "AmbulantaId");
            DropColumn("dbo.AspNetUsers", "IsDoctor");
        }
    }
}
