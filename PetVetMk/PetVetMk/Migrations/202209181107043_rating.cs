namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VeterinarnaAmbulantaRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ambulantaId = c.Int(nullable: false),
                        korisnikId = c.Int(nullable: false),
                        rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VeterinarnaAmbulantaRatings");
        }
    }
}
