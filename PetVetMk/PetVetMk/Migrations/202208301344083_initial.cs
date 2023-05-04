namespace PetVetMk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mileniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MilenikIme = c.String(),
                        MilenikSopstvenik = c.String(),
                        MilenikDataRaganje = c.String(),
                        MilenikVid = c.String(),
                        MilenikRasa = c.String(),
                        MilenikBoja = c.String(),
                        VeterinarnaAmbulanta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VeterinarnaAmbulantas", t => t.VeterinarnaAmbulanta_Id)
                .Index(t => t.VeterinarnaAmbulanta_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VeterinarnaAmbulantas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VetAmbulantaIme = c.String(),
                        VetAmbulantaLogoUrl = c.String(),
                        VetAmbulantaOpstina = c.String(),
                        VetAmbulantaAdresa = c.String(),
                        VetAmbulantaRabotnoVreme = c.String(),
                        VetAmbulantaEmail = c.String(),
                        VetAmbulantaTelBroj = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VeterinarenDoktors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoktorImePrezime = c.String(),
                        DoktorOpstina = c.String(),
                        DoktorTelBroj = c.Int(nullable: false),
                        DoktorEmail = c.String(),
                        VeterinarnaAmbulanta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VeterinarnaAmbulantas", t => t.VeterinarnaAmbulanta_Id)
                .Index(t => t.VeterinarnaAmbulanta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VeterinarenDoktors", "VeterinarnaAmbulanta_Id", "dbo.VeterinarnaAmbulantas");
            DropForeignKey("dbo.Mileniks", "VeterinarnaAmbulanta_Id", "dbo.VeterinarnaAmbulantas");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.VeterinarenDoktors", new[] { "VeterinarnaAmbulanta_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Mileniks", new[] { "VeterinarnaAmbulanta_Id" });
            DropTable("dbo.VeterinarenDoktors");
            DropTable("dbo.VeterinarnaAmbulantas");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Mileniks");
        }
    }
}
