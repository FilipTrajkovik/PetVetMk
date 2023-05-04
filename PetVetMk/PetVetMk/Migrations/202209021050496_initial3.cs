namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VeterinarenDoktors", "veterinarenDoktor_Id", c => c.Int());
            CreateIndex("dbo.VeterinarenDoktors", "veterinarenDoktor_Id");
            AddForeignKey("dbo.VeterinarenDoktors", "veterinarenDoktor_Id", "dbo.VeterinarenDoktors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VeterinarenDoktors", "veterinarenDoktor_Id", "dbo.VeterinarenDoktors");
            DropIndex("dbo.VeterinarenDoktors", new[] { "veterinarenDoktor_Id" });
            DropColumn("dbo.VeterinarenDoktors", "veterinarenDoktor_Id");
        }
    }
}
