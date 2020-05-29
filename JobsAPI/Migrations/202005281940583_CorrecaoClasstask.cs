namespace JobsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecaoClasstask : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "ParentJobId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "ParentJobId", c => c.Boolean(nullable: false));
        }
    }
}
