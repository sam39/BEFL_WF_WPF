namespace BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NetName = c.String(),
                        CpuName = c.String(),
                        CpuCoreNum = c.String(),
                        Memory = c.String(),
                        Hdd = c.String(),
                        CdRom = c.String(),
                        OS = c.String(),
                        MainBoard = c.String(),
                        Video = c.String(),
                        Monitor = c.String(),
                        CompType_Id = c.Int(),
                        Emp_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DicDatas", t => t.CompType_Id)
                .ForeignKey("dbo.Emps", t => t.Emp_Id)
                .Index(t => t.CompType_Id)
                .Index(t => t.Emp_Id);
            
            CreateTable(
                "dbo.DicDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Dic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dics", t => t.Dic_Id)
                .Index(t => t.Dic_Id);
            
            CreateTable(
                "dbo.Dics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        Name = c.String(),
                        SName = c.String(),
                        PosId = c.Int(),
                        DepId = c.Int(),
                        InternalTel = c.String(),
                        MobileTel = c.String(),
                        Email = c.String(),
                        EmailPass = c.String(),
                        DomainPass = c.String(),
                        TrueCryptPass = c.String(),
                        ERoomPass = c.String(),
                        SkypeName = c.String(),
                        SkypePass = c.String(),
                        IcqName = c.String(),
                        IcqPass = c.String(),
                        Gmail = c.String(),
                        Mango = c.String(),
                        Comments = c.String(),
                        HideInSpr = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deps", t => t.DepId)
                .ForeignKey("dbo.Pos", t => t.PosId)
                .Index(t => t.PosId)
                .Index(t => t.DepId);
            
            CreateTable(
                "dbo.Deps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Monitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Comment = c.String(),
                        InvNum = c.String(),
                        Diagonal_Id = c.Int(),
                        Emp_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DicDatas", t => t.Diagonal_Id)
                .ForeignKey("dbo.Emps", t => t.Emp_Id)
                .Index(t => t.Diagonal_Id)
                .Index(t => t.Emp_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Monitors", "Emp_Id", "dbo.Emps");
            DropForeignKey("dbo.Monitors", "Diagonal_Id", "dbo.DicDatas");
            DropForeignKey("dbo.Comps", "Emp_Id", "dbo.Emps");
            DropForeignKey("dbo.Emps", "PosId", "dbo.Pos");
            DropForeignKey("dbo.Emps", "DepId", "dbo.Deps");
            DropForeignKey("dbo.Comps", "CompType_Id", "dbo.DicDatas");
            DropForeignKey("dbo.DicDatas", "Dic_Id", "dbo.Dics");
            DropIndex("dbo.Monitors", new[] { "Emp_Id" });
            DropIndex("dbo.Monitors", new[] { "Diagonal_Id" });
            DropIndex("dbo.Emps", new[] { "DepId" });
            DropIndex("dbo.Emps", new[] { "PosId" });
            DropIndex("dbo.DicDatas", new[] { "Dic_Id" });
            DropIndex("dbo.Comps", new[] { "Emp_Id" });
            DropIndex("dbo.Comps", new[] { "CompType_Id" });
            DropTable("dbo.Monitors");
            DropTable("dbo.Pos");
            DropTable("dbo.Deps");
            DropTable("dbo.Emps");
            DropTable("dbo.Dics");
            DropTable("dbo.DicDatas");
            DropTable("dbo.Comps");
        }
    }
}
