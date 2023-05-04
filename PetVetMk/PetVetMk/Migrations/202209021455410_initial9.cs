namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VeterinarnaAmbulantas", "VetAmbulantaTelBroj", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VeterinarnaAmbulantas", "VetAmbulantaTelBroj", c => c.Int(nullable: false));
        }
    }
}
