namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class celbroj : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VeterinarnaAmbulantas", "VetAmbulantaTelBroj", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VeterinarnaAmbulantas", "VetAmbulantaTelBroj", c => c.Int());
        }
    }
}
