namespace BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewCOmpAttr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comps", "OS", c => c.String());
            AddColumn("dbo.Comps", "MainBoard", c => c.String());
            AddColumn("dbo.Comps", "Video", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comps", "Video");
            DropColumn("dbo.Comps", "MainBoard");
            DropColumn("dbo.Comps", "OS");
        }
    }
}
