namespace SchoolAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAttachment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attachments", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attachments", "FileName");
        }
    }
}
