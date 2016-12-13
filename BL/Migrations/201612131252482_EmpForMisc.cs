namespace BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmpForMisc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Miscs", "Emp_Id", c => c.Int());
            CreateIndex("dbo.Miscs", "Emp_Id");
            AddForeignKey("dbo.Miscs", "Emp_Id", "dbo.Emps", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Miscs", "Emp_Id", "dbo.Emps");
            DropIndex("dbo.Miscs", new[] { "Emp_Id" });
            DropColumn("dbo.Miscs", "Emp_Id");
        }
    }
}
