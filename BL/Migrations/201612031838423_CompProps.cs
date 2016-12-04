namespace BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comps", "Hdd", c => c.String());
            AddColumn("dbo.Comps", "CdRom", c => c.String());
            AddColumn("dbo.Comps", "Emp_Id", c => c.Int());
            CreateIndex("dbo.Comps", "Emp_Id");
            AddForeignKey("dbo.Comps", "Emp_Id", "dbo.Emps", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comps", "Emp_Id", "dbo.Emps");
            DropIndex("dbo.Comps", new[] { "Emp_Id" });
            DropColumn("dbo.Comps", "Emp_Id");
            DropColumn("dbo.Comps", "CdRom");
            DropColumn("dbo.Comps", "Hdd");
        }
    }
}
