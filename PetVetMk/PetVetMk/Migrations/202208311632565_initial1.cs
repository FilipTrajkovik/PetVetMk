namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VeterinarnaAmbulantas", "VetAmbKratokOpis", c => c.String());
            AddColumn("dbo.VeterinarnaAmbulantas", "VetAmbDolgOpis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VeterinarnaAmbulantas", "VetAmbDolgOpis");
            DropColumn("dbo.VeterinarnaAmbulantas", "VetAmbKratokOpis");
        }
    }
}
