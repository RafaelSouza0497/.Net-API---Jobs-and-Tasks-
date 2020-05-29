namespace JobsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTaskClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "ParentJobId", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tasks", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "Name", c => c.String());
            DropColumn("dbo.Tasks", "ParentJobId");
        }
    }
}
