namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreToRegionAndArea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Store.Store_SupprtedArea",
                c => new
                    {
                        StoreId = c.Guid(nullable: false),
                        AreaName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => new { t.StoreId, t.AreaName })
                .ForeignKey("Store.Store", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("Location.Area", t => t.AreaName, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.AreaName);
            
            CreateTable(
                "Store.Store_SupprtedRegion",
                c => new
                    {
                        StoreId = c.Guid(nullable: false),
                        RegionName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => new { t.StoreId, t.RegionName })
                .ForeignKey("Store.Store", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("Location.Region", t => t.RegionName, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.RegionName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Store.Store_SupprtedRegion", "RegionName", "Location.Region");
            DropForeignKey("Store.Store_SupprtedRegion", "StoreId", "Store.Store");
            DropForeignKey("Store.Store_SupprtedArea", "AreaName", "Location.Area");
            DropForeignKey("Store.Store_SupprtedArea", "StoreId", "Store.Store");
            DropIndex("Store.Store_SupprtedRegion", new[] { "RegionName" });
            DropIndex("Store.Store_SupprtedRegion", new[] { "StoreId" });
            DropIndex("Store.Store_SupprtedArea", new[] { "AreaName" });
            DropIndex("Store.Store_SupprtedArea", new[] { "StoreId" });
            DropTable("Store.Store_SupprtedRegion");
            DropTable("Store.Store_SupprtedArea");
        }
    }
}
