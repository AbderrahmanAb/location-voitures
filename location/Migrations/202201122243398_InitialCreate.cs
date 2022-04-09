namespace location.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        CategorieID = c.Int(nullable: false, identity: true),
                        type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategorieID);
            
            CreateTable(
                "dbo.clts",
                c => new
                    {
                        CID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 100),
                        AdresseMail = c.String(nullable: false, maxLength: 100),
                        MotDePasse = c.String(nullable: false, maxLength: 100),
                        DateNaissance = c.DateTime(nullable: false, storeType: "date"),
                        CIN = c.String(),
                        permis = c.String(),
                    })
                .PrimaryKey(t => t.CID);
            
            CreateTable(
                "dbo.Modeles",
                c => new
                    {
                        modelID = c.Int(nullable: false, identity: true),
                        nom = c.String(maxLength: 50),
                        serie = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.modelID);
            
            CreateTable(
                "dbo.voitures",
                c => new
                    {
                        voitureID = c.Int(nullable: false, identity: true),
                        numero_matriculation = c.String(),
                        date_mise_circulation = c.DateTime(nullable: false, storeType: "date"),
                        carburant = c.Int(nullable: false),
                        image = c.Binary(),
                        categorieID = c.Int(nullable: false),
                        modelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.voitureID)
                .ForeignKey("dbo.categories", t => t.categorieID, cascadeDelete: true)
                .ForeignKey("dbo.Modeles", t => t.modelID, cascadeDelete: true)
                .Index(t => t.categorieID)
                .Index(t => t.modelID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.voitures", "modelID", "dbo.Modeles");
            DropForeignKey("dbo.voitures", "categorieID", "dbo.categories");
            DropIndex("dbo.voitures", new[] { "modelID" });
            DropIndex("dbo.voitures", new[] { "categorieID" });
            DropTable("dbo.voitures");
            DropTable("dbo.Modeles");
            DropTable("dbo.clts");
            DropTable("dbo.categories");
        }
    }
}
