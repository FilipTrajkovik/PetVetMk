namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class odberiuloga : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Role", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Role", c => c.Boolean(nullable: false));
        }
    }
}
