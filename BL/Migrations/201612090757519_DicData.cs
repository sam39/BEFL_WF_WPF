namespace BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DicData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Comps", "CompType_Id", c => c.Int());
            CreateIndex("dbo.Comps", "CompType_Id");
            AddForeignKey("dbo.Comps", "CompType_Id", "dbo.CompTypes", "Id");
            DropColumn("dbo.Comps", "CompType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comps", "CompType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comps", "CompType_Id", "dbo.CompTypes");
            DropIndex("dbo.Comps", new[] { "CompType_Id" });
            DropColumn("dbo.Comps", "CompType_Id");
            DropTable("dbo.CompTypes");
        }
    }
}
