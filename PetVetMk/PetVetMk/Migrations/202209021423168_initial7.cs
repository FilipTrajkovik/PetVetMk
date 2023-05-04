namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VeterinarenDoktors", "DoktorImePrezime", c => c.String(nullable: false));
            AlterColumn("dbo.VeterinarenDoktors", "DoktorOpstina", c => c.String(nullable: false));
            AlterColumn("dbo.VeterinarenDoktors", "DoktorEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VeterinarenDoktors", "DoktorEmail", c => c.String());
            AlterColumn("dbo.VeterinarenDoktors", "DoktorOpstina", c => c.String());
            AlterColumn("dbo.VeterinarenDoktors", "DoktorImePrezime", c => c.String());
        }
    }
}
