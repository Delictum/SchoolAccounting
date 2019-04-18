namespace SchoolAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAttachments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentId = c.Int(nullable: false),
                        File = c.Binary(),
                        MadeBy = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.PaymentId);
            
            DropColumn("dbo.Payments", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "File", c => c.Binary());
            DropForeignKey("dbo.Attachments", "PaymentId", "dbo.Payments");
            DropIndex("dbo.Attachments", new[] { "PaymentId" });
            DropTable("dbo.Attachments");
        }
    }
}
