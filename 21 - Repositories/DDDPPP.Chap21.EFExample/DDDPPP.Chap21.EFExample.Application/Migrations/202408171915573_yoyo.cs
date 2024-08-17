namespace DDDPPP.Chap21.EFExample.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yoyo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AuctionEnds = c.DateTime(nullable: false),
                        BidderMemberId = c.Guid(),
                        TimeOfBid = c.DateTime(),
                        MaximumBid = c.Decimal(precision: 18, scale: 2),
                        CurrentPrice = c.Decimal(precision: 18, scale: 2),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BidHistory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AuctionId = c.Guid(nullable: false),
                        BidderId = c.Guid(nullable: false),
                        Bid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeOfBid = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BidHistory");
            DropTable("dbo.Auctions");
        }
    }
}
