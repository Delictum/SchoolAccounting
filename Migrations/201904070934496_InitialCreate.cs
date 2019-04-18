namespace SchoolAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accountings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        TypeClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeOfService = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        Access = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accountings", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Accountings", "ClientId", "dbo.Clients");
            DropIndex("dbo.Accountings", new[] { "ClientId" });
            DropIndex("dbo.Accountings", new[] { "ServiceId" });
            DropTable("dbo.Services");
            DropTable("dbo.Clients");
            DropTable("dbo.Accountings");
        }
    }
}
