namespace BEFLSPR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qwer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MCs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvNum = c.String(),
                        Ip = c.String(),
                        NetName = c.String(),
                        CPU = c.String(),
                        MainBoard = c.String(),
                        RAM = c.String(),
                        HDD = c.String(),
                        CDROM = c.String(),
                        UserId = c.Int(),
                        Diagonal = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emps", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AlterColumn("dbo.Emps", "PosId", c => c.Int());
            AlterColumn("dbo.Emps", "DepId", c => c.Int());
        }
        
        public override void Down()
        {
            DropIndex("dbo.MCs", new[] { "UserId" });
            DropForeignKey("dbo.MCs", "UserId", "dbo.Emps");
            AlterColumn("dbo.Emps", "DepId", c => c.Int());
            AlterColumn("dbo.Emps", "PosId", c => c.Int());
            DropTable("dbo.MCs");
        }
    }
}
