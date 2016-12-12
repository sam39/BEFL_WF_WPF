namespace BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compsAdd : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Deps",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Emps",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            LastName = c.String(),
            //            Name = c.String(),
            //            SName = c.String(),
            //            PosId = c.Int(),
            //            DepId = c.Int(),
            //            InternalTel = c.String(),
            //            MobileTel = c.String(),
            //            Email = c.String(),
            //            EmailPass = c.String(),
            //            DomainPass = c.String(),
            //            TrueCryptPass = c.String(),
            //            ERoomPass = c.String(),
            //            SkypeName = c.String(),
            //            SkypePass = c.String(),
            //            IcqName = c.String(),
            //            IcqPass = c.String(),
            //            Gmail = c.String(),
            //            Mango = c.String(),
            //            Comments = c.String(),
            //            HideInSpr = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Deps", t => t.DepId)
            //    .ForeignKey("dbo.Pos", t => t.PosId)
            //    .Index(t => t.PosId)
            //    .Index(t => t.DepId);
            
            //CreateTable(
            //    "dbo.Pos",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emps", "PosId", "dbo.Pos");
            DropForeignKey("dbo.Emps", "DepId", "dbo.Deps");
            DropIndex("dbo.Emps", new[] { "DepId" });
            DropIndex("dbo.Emps", new[] { "PosId" });
            DropTable("dbo.Pos");
            DropTable("dbo.Emps");
            DropTable("dbo.Deps");
            DropTable("dbo.Comps");
        }
    }
}
