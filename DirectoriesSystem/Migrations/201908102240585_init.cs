namespace DirectoriesSystem
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(),
                        Other = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Folders", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Folders", "ParentId", "dbo.Folders");
            DropIndex("dbo.Folders", new[] { "ParentId" });
            DropTable("dbo.Folders");
        }
    }
}
