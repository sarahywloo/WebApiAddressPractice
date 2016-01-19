namespace WebApiAddressPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BillingAddress_Id = c.Int(),
                        ShippingAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.BillingAddress_Id)
                .ForeignKey("dbo.Addresses", t => t.ShippingAddress_Id)
                .Index(t => t.BillingAddress_Id)
                .Index(t => t.ShippingAddress_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ShippingAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "BillingAddress_Id", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "ShippingAddress_Id" });
            DropIndex("dbo.Customers", new[] { "BillingAddress_Id" });
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
