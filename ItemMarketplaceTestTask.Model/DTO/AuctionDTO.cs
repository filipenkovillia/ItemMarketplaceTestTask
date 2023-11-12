using ItemMarketplaceTestTask.Model.Enums;

namespace ItemMarketplaceTestTask.Model.DTO
{
    public class AuctionDTO
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public decimal? Price { get; set; }
        public AuctionStatus Status { get; set; }
        public string Seller { get; set; }
        public string? Buyer { get; set; }
    }
}
