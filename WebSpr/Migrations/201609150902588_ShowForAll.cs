namespace BEFLSPR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowForAll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emps", "ShowForAll", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emps", "ShowForAll");
        }
    }
}
