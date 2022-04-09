namespace location.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mi1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.clts", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.clts", "IsAdmin");
        }
    }
}
