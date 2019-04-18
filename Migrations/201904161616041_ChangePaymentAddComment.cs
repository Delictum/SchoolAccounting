namespace SchoolAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePaymentAddComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "Comment");
        }
    }
}
