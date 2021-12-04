namespace OrderManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "AdditionalCost", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "AdditionalCost");
        }
    }
}
