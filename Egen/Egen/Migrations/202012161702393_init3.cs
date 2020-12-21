namespace Egen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Invoices", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Consultants", new[] { "ProjectId" });
            DropIndex("dbo.Invoices", new[] { "BankId" });
            DropIndex("dbo.Invoices", new[] { "ProjectId" });
            DropIndex("dbo.Invoices", new[] { "CompanyId" });
            AlterColumn("dbo.Consultants", "ProjectId", c => c.Int());
            AlterColumn("dbo.Invoices", "BankId", c => c.Int());
            AlterColumn("dbo.Invoices", "ProjectId", c => c.Int());
            AlterColumn("dbo.Invoices", "CompanyId", c => c.Int());
            CreateIndex("dbo.Consultants", "ProjectId");
            CreateIndex("dbo.Invoices", "BankId");
            CreateIndex("dbo.Invoices", "ProjectId");
            CreateIndex("dbo.Invoices", "CompanyId");
            AddForeignKey("dbo.Invoices", "BankId", "dbo.Banks", "BankId");
            AddForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects", "ProjectId");
            AddForeignKey("dbo.Invoices", "CompanyId", "dbo.Companies", "CompanyId");
            AddForeignKey("dbo.Invoices", "ProjectId", "dbo.Projects", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Invoices", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Invoices", "BankId", "dbo.Banks");
            DropIndex("dbo.Invoices", new[] { "CompanyId" });
            DropIndex("dbo.Invoices", new[] { "ProjectId" });
            DropIndex("dbo.Invoices", new[] { "BankId" });
            DropIndex("dbo.Consultants", new[] { "ProjectId" });
            AlterColumn("dbo.Invoices", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "BankId", c => c.Int(nullable: false));
            AlterColumn("dbo.Consultants", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "CompanyId");
            CreateIndex("dbo.Invoices", "ProjectId");
            CreateIndex("dbo.Invoices", "BankId");
            CreateIndex("dbo.Consultants", "ProjectId");
            AddForeignKey("dbo.Invoices", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
            AddForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "BankId", "dbo.Banks", "BankId", cascadeDelete: true);
        }
    }
}
