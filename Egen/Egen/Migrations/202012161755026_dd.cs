namespace Egen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Consultants", new[] { "ProjectId" });
            AlterColumn("dbo.Consultants", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Consultants", "ProjectId");
            AddForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Consultants", new[] { "ProjectId" });
            AlterColumn("dbo.Consultants", "ProjectId", c => c.Int());
            CreateIndex("dbo.Consultants", "ProjectId");
            AddForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects", "ProjectId");
        }
    }
}
