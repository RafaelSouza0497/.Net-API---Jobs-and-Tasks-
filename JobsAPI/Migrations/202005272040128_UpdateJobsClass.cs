namespace JobsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJobsClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.Tasks", new[] { "Job_Id" });
            DropColumn("dbo.Tasks", "Job_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Job_Id", c => c.Int());
            CreateIndex("dbo.Tasks", "Job_Id");
            AddForeignKey("dbo.Tasks", "Job_Id", "dbo.Jobs", "Id");
        }
    }
}
