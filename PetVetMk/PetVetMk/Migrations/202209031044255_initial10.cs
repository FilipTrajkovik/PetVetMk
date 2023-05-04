namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mileniks", "MilenikIme", c => c.String(nullable: false));
            AlterColumn("dbo.Mileniks", "MilenikSopstvenik", c => c.String(nullable: false));
            AlterColumn("dbo.Mileniks", "MilenikDataRaganje", c => c.String(nullable: false));
            AlterColumn("dbo.Mileniks", "MilenikVid", c => c.String(nullable: false));
            AlterColumn("dbo.Mileniks", "MilenikRasa", c => c.String(nullable: false));
            AlterColumn("dbo.Mileniks", "MilenikBoja", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mileniks", "MilenikBoja", c => c.String());
            AlterColumn("dbo.Mileniks", "MilenikRasa", c => c.String());
            AlterColumn("dbo.Mileniks", "MilenikVid", c => c.String());
            AlterColumn("dbo.Mileniks", "MilenikDataRaganje", c => c.String());
            AlterColumn("dbo.Mileniks", "MilenikSopstvenik", c => c.String());
            AlterColumn("dbo.Mileniks", "MilenikIme", c => c.String());
        }
    }
}
