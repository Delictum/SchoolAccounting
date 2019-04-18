namespace SchoolAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Paid = c.Boolean(nullable: false),
                        File = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Accountings", "PaymentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accountings", "PaymentId");
            DropTable("dbo.Payments");
        }
    }
}
