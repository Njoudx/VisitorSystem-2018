namespace VisitorSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authorizors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ALJAccount = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        isEnable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArName = c.String(),
                        isEnable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        ArType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IDTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestRejectionReasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReasonId = c.Int(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        RequestFrom = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        Company = c.String(nullable: false),
                        VisitorSystem = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        ISFFilePath = c.String(),
                        AuthorizorId = c.Int(nullable: false),
                        FirstApproval = c.Int(nullable: false),
                        ISSApproval = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Reasons", t => t.ReasonId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ReasonId)
                .Index(t => t.DepartmentId)
                .Index(t => t.StatusId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarTypeId = c.Int(nullable: false),
                        Model = c.String(),
                        PlateNumber = c.String(),
                        Color = c.String(),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ArName = c.String(nullable: false),
                        NationalityId = c.Int(nullable: false),
                        IDTypeId = c.Int(nullable: false),
                        IdNumber = c.String(nullable: false),
                        Arrived = c.Boolean(nullable: false),
                        RequestId = c.Int(nullable: false),
                        Document1 = c.Binary(),
                        Document2 = c.Binary(),
                        firstDoc = c.String(),
                        secondDoc = c.String(),
                        ctDoc1 = c.String(),
                        ctDoc2 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IDTypes", t => t.IDTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Nationalities", t => t.NationalityId, cascadeDelete: true)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.NationalityId)
                .Index(t => t.IDTypeId)
                .Index(t => t.RequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestRejectionReasons", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Visitors", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Visitors", "NationalityId", "dbo.Nationalities");
            DropForeignKey("dbo.Visitors", "IDTypeId", "dbo.IDTypes");
            DropForeignKey("dbo.Vehicles", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Requests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Requests", "ReasonId", "dbo.Reasons");
            DropForeignKey("dbo.Requests", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Requests", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Authorizors", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Visitors", new[] { "RequestId" });
            DropIndex("dbo.Visitors", new[] { "IDTypeId" });
            DropIndex("dbo.Visitors", new[] { "NationalityId" });
            DropIndex("dbo.Vehicles", new[] { "RequestId" });
            DropIndex("dbo.Requests", new[] { "LocationId" });
            DropIndex("dbo.Requests", new[] { "StatusId" });
            DropIndex("dbo.Requests", new[] { "DepartmentId" });
            DropIndex("dbo.Requests", new[] { "ReasonId" });
            DropIndex("dbo.RequestRejectionReasons", new[] { "RequestId" });
            DropIndex("dbo.Authorizors", new[] { "DepartmentId" });
            DropTable("dbo.Visitors");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Status");
            DropTable("dbo.Requests");
            DropTable("dbo.RequestRejectionReasons");
            DropTable("dbo.Reasons");
            DropTable("dbo.Nationalities");
            DropTable("dbo.Locations");
            DropTable("dbo.IDTypes");
            DropTable("dbo.CarTypes");
            DropTable("dbo.Departments");
            DropTable("dbo.Authorizors");
        }
    }
}
