namespace JobsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correcao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Job_Id", c => c.Int());
            CreateIndex("dbo.Tasks", "Job_Id");
            AddForeignKey("dbo.Tasks", "Job_Id", "dbo.Jobs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.Tasks", new[] { "Job_Id" });
            DropColumn("dbo.Tasks", "Job_Id");
        }
    }
}
