namespace Egen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        BankId = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        AccountNumber = c.String(),
                        Iban = c.String(),
                        BankName = c.String(),
                        SwiftCode = c.String(),
                        RoutingType = c.String(),
                        RoutingNumber = c.String(),
                        BankCountry = c.String(),
                        BankBranch = c.String(),
                        ConsultantId = c.Int(),
                    })
                .PrimaryKey(t => t.BankId)
                .ForeignKey("dbo.Consultants", t => t.ConsultantId)
                .Index(t => t.ConsultantId);
            
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        ConsultantId = c.Int(nullable: false, identity: true),
                        ConsultantName = c.String(),
                        ConsultantDesignation = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultantId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        InvoiceNo = c.String(),
                        BankId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        ConsultantId = c.Int(),
                        CompanyId = c.Int(nullable: false),
                        IsUsd = c.Boolean(nullable: false),
                        Total = c.Decimal(precision: 18, scale: 2),
                        Advance = c.Decimal(precision: 18, scale: 2),
                        Due = c.Decimal(precision: 18, scale: 2),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Remuneration = c.String(),
                        RemunerationDetails = c.String(),
                        RemunerationWorkingDays = c.Int(),
                        RemunerationDailyRate = c.Decimal(precision: 18, scale: 2),
                        RemunerationTotal = c.Decimal(precision: 18, scale: 2),
                        PerDiem = c.String(),
                        PerDiemDetails = c.String(),
                        PerDiemWorkingDays = c.Int(),
                        PerDiemDailyRate = c.Decimal(precision: 18, scale: 2),
                        PerDiemTotal = c.Decimal(precision: 18, scale: 2),
                        AirFare = c.String(),
                        AirFareDetails = c.String(),
                        AirFareTotal = c.Decimal(precision: 18, scale: 2),
                        Accommodation = c.String(),
                        AccommodationDetails = c.String(),
                        AccommodationTotal = c.Decimal(precision: 18, scale: 2),
                        VisaFees = c.String(),
                        VisaFeesDetails = c.String(),
                        VisaFeesTotal = c.Decimal(precision: 18, scale: 2),
                        TaxiFare = c.String(),
                        TaxiFareDetails = c.String(),
                        TaxiFareTotal = c.Decimal(precision: 18, scale: 2),
                        Other = c.String(),
                        OtherDetails = c.String(),
                        OtherWorkingDays = c.Int(),
                        OtherDailyRate = c.Decimal(precision: 18, scale: 2),
                        OtherTotal = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Consultants", t => t.ConsultantId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.BankId)
                .Index(t => t.ProjectId)
                .Index(t => t.ConsultantId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyAddress = c.String(),
                        Attention = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectCode = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Invoices", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Consultants", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Invoices", "ConsultantId", "dbo.Consultants");
            DropForeignKey("dbo.Invoices", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Banks", "ConsultantId", "dbo.Consultants");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Invoices", new[] { "CompanyId" });
            DropIndex("dbo.Invoices", new[] { "ConsultantId" });
            DropIndex("dbo.Invoices", new[] { "ProjectId" });
            DropIndex("dbo.Invoices", new[] { "BankId" });
            DropIndex("dbo.Consultants", new[] { "ProjectId" });
            DropIndex("dbo.Banks", new[] { "ConsultantId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Projects");
            DropTable("dbo.Companies");
            DropTable("dbo.Invoices");
            DropTable("dbo.Consultants");
            DropTable("dbo.Banks");
        }
    }
}
