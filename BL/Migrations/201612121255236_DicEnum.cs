namespace BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DicEnum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DicDatas", "Dic_Id", "dbo.Dics");
            DropIndex("dbo.DicDatas", new[] { "Dic_Id" });
            AddColumn("dbo.DicDatas", "Dic", c => c.Int(nullable: false));
            DropColumn("dbo.DicDatas", "Dic_Id");
            DropTable("dbo.Dics");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Dics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DicDatas", "Dic_Id", c => c.Int());
            DropColumn("dbo.DicDatas", "Dic");
            CreateIndex("dbo.DicDatas", "Dic_Id");
            AddForeignKey("dbo.DicDatas", "Dic_Id", "dbo.Dics", "Id");
        }
    }
}
