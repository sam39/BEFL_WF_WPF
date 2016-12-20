namespace BEFLSPR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HideInSpr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emps", "HideInSpr", c => c.Boolean(nullable: false));
            DropColumn("dbo.Emps", "ShowForAll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emps", "ShowForAll", c => c.Boolean(nullable: false));
            DropColumn("dbo.Emps", "HideInSpr");
        }
    }
}
