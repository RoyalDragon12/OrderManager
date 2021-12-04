namespace OrderManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exchanges",
                c => new
                    {
                        ExchangeId = c.Int(nullable: false, identity: true),
                        ExchangeName = c.String(),
                        DisplayName = c.String(),
                        ExchangeNum = c.Double(nullable: false),
                        ExchangeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExchangeId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ProductName = c.String(),
                        CostPerProduct = c.Double(nullable: false),
                        Amount = c.Int(nullable: false),
                        CNY = c.Double(nullable: false),
                        ProductLink = c.String(),
                        InterestRate = c.Single(nullable: false),
                        TotalCost = c.Double(nullable: false),
                        FinalCost = c.Double(nullable: false),
                        ServiceFee = c.Single(nullable: false),
                        Weight = c.Single(nullable: false),
                        WeightCost = c.Double(nullable: false),
                        TotalWeightCost = c.Single(nullable: false),
                        Size = c.String(),
                        Model = c.String(),
                        Note = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        LadingNo = c.String(),
                        ShopName = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        Shipper = c.String(),
                        packageCreated = c.Boolean(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Deposit = c.Double(nullable: false),
                        TotalWeight = c.Single(nullable: false),
                        TotalWeightCost = c.Double(nullable: false),
                        LeftOver = c.Double(nullable: false),
                        ProductCost = c.Double(nullable: false),
                        TotalCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Exchanges");
        }
    }
}
