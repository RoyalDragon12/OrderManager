namespace OrderManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "AdditionalCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "AdditionalCost", c => c.Single(nullable: false));
        }
    }
}
