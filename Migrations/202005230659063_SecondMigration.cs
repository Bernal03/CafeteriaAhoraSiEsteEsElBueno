namespace CafeteriaAhoraSiEsteEsElBueno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pedids", "Total");
            DropColumn("dbo.Pedids", "Estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedids", "Estado", c => c.String());
            AddColumn("dbo.Pedids", "Total", c => c.Int(nullable: false));
        }
    }
}
