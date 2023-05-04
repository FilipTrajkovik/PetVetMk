namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Mileniks", new[] { "VeterinarnaAmbulanta_Id" });
            CreateIndex("dbo.Mileniks", "veterinarnaAmbulanta_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Mileniks", new[] { "veterinarnaAmbulanta_Id" });
            CreateIndex("dbo.Mileniks", "VeterinarnaAmbulanta_Id");
        }
    }
}
