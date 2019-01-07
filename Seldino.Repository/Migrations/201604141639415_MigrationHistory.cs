namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationHistory : DbMigration
    {
        public override void Up()
        {
            DropTable("Setting.MigrationHistory");
        }
        
        public override void Down()
        {
            CreateTable(
                "Setting.MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 128),
                        ContextKey = c.String(),
                        Model = c.Binary(),
                        ProductVersion = c.String(),
                    })
                .PrimaryKey(t => t.MigrationId);
            
        }
    }
}
