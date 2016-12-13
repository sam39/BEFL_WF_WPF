namespace BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miscAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Miscs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dsc = c.String(),
                        InvNum = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Miscs");
        }
    }
}
