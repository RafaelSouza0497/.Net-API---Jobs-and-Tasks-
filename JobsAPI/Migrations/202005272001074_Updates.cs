namespace JobsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Jobs", new[] { "ParentJob_Id" });
            AlterColumn("dbo.Jobs", "ParentJob_Id", c => c.Int());
            CreateIndex("dbo.Jobs", "ParentJob_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Jobs", new[] { "ParentJob_Id" });
            AlterColumn("dbo.Jobs", "ParentJob_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "ParentJob_Id");
        }
    }
}
