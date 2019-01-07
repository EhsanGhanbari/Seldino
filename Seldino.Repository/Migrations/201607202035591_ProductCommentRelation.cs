namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCommentRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Membership.User_ProductComment", "UserId", "Membership.User");
            DropForeignKey("Membership.User_ProductComment", "ProductCommentId", "Product.ProductComment");
            DropIndex("Membership.User_ProductComment", new[] { "UserId" });
            DropIndex("Membership.User_ProductComment", new[] { "ProductCommentId" });
            AddColumn("Product.ProductComment", "UserId", c => c.Guid());
            CreateIndex("Product.ProductComment", "UserId");
            AddForeignKey("Product.ProductComment", "UserId", "Membership.User", "Id");
            DropTable("Membership.User_ProductComment");
        }
        
        public override void Down()
        {
            CreateTable(
                "Membership.User_ProductComment",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        ProductCommentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProductCommentId });
            
            DropForeignKey("Product.ProductComment", "UserId", "Membership.User");
            DropIndex("Product.ProductComment", new[] { "UserId" });
            DropColumn("Product.ProductComment", "UserId");
            CreateIndex("Membership.User_ProductComment", "ProductCommentId");
            CreateIndex("Membership.User_ProductComment", "UserId");
            AddForeignKey("Membership.User_ProductComment", "ProductCommentId", "Product.ProductComment", "Id", cascadeDelete: true);
            AddForeignKey("Membership.User_ProductComment", "UserId", "Membership.User", "Id", cascadeDelete: true);
        }
    }
}
