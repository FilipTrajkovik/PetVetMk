namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeuseridtostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VeterinarnaAmbulantaRatings", "korisnikId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VeterinarnaAmbulantaRatings", "korisnikId", c => c.Int(nullable: false));
        }
    }
}
