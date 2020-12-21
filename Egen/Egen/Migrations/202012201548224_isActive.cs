namespace Egen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "IsActive", c => c.Boolean());
            AddColumn("dbo.Consultants", "IsActive", c => c.Boolean());
            AddColumn("dbo.Projects", "IsActive", c => c.Boolean());
            AddColumn("dbo.Companies", "IsActive", c => c.Boolean());
            AddColumn("dbo.Invoices", "IsActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "IsActive");
            DropColumn("dbo.Companies", "IsActive");
            DropColumn("dbo.Projects", "IsActive");
            DropColumn("dbo.Consultants", "IsActive");
            DropColumn("dbo.Banks", "IsActive");
        }
    }
}
