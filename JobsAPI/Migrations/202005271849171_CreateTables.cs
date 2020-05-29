namespace JobsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Active = c.Boolean(nullable: false),
                        ParentJob_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.ParentJob_Id)
                .Index(t => t.ParentJob_Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.Int(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Job_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .Index(t => t.Job_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "ParentJob_Id", "dbo.Jobs");
            DropIndex("dbo.Tasks", new[] { "Job_Id" });
            DropIndex("dbo.Jobs", new[] { "ParentJob_Id" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Jobs");
        }
    }
}
