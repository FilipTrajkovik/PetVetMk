namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VeterinarenDoktors", "veterinarenDoktor_Id", "dbo.VeterinarenDoktors");
            DropIndex("dbo.VeterinarenDoktors", new[] { "veterinarenDoktor_Id" });
            DropIndex("dbo.VeterinarenDoktors", new[] { "VeterinarnaAmbulanta_Id" });
            CreateIndex("dbo.VeterinarenDoktors", "veterinarnaAmbulanta_Id");
            DropColumn("dbo.VeterinarenDoktors", "veterinarenDoktor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VeterinarenDoktors", "veterinarenDoktor_Id", c => c.Int());
            DropIndex("dbo.VeterinarenDoktors", new[] { "veterinarnaAmbulanta_Id" });
            CreateIndex("dbo.VeterinarenDoktors", "VeterinarnaAmbulanta_Id");
            CreateIndex("dbo.VeterinarenDoktors", "veterinarenDoktor_Id");
            AddForeignKey("dbo.VeterinarenDoktors", "veterinarenDoktor_Id", "dbo.VeterinarenDoktors", "Id");
        }
    }
}
