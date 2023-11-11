using ItemMarketplaceTestTask.Model.Enum;
using System.Text.Json.Serialization;

namespace ItemMarketplaceTestTask.Model.Entities
{
    public class Auction
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public decimal Price { get; set; }
        public AuctionStatus Status { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }

        [JsonIgnore]
        public Item Item { get; set; }
    }
}
