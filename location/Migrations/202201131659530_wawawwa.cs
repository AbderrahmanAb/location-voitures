namespace location.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wawawwa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.locatvoitures",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        voitureID = c.Int(nullable: false),
                        cltID = c.Int(nullable: false),
                        clt_CID = c.Int(),
                    })
                .PrimaryKey(t => t.LocationID)
                .ForeignKey("dbo.clts", t => t.clt_CID)
                .ForeignKey("dbo.voitures", t => t.voitureID, cascadeDelete: true)
                .Index(t => t.voitureID)
                .Index(t => t.clt_CID);
            
            AddColumn("dbo.voitures", "prix_Par_Jour", c => c.Int(nullable: false));
            AlterColumn("dbo.voitures", "image", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.locatvoitures", "voitureID", "dbo.voitures");
            DropForeignKey("dbo.locatvoitures", "clt_CID", "dbo.clts");
            DropIndex("dbo.locatvoitures", new[] { "clt_CID" });
            DropIndex("dbo.locatvoitures", new[] { "voitureID" });
            AlterColumn("dbo.voitures", "image", c => c.Binary());
            DropColumn("dbo.voitures", "prix_Par_Jour");
            DropTable("dbo.locatvoitures");
        }
    }
}
