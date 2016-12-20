namespace BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompToMc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comps", "InvNum", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comps", "InvNum");
        }
    }
}
