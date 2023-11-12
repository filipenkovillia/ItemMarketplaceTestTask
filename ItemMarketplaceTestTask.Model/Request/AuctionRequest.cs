using ItemMarketplaceTestTask.Model.Enums;

namespace ItemMarketplaceTestTask.Model.Request
{
    public class AuctionRequest
    {
        public int PageNumber { get; set; } = 1;
        public int Limit { get; set; } = 10;
        public AuctionStatus? Status { get; set; }
        public string? Seller { get; set; }
        public string? Name { get; set; }
        public string SortKey { get; set; } = "createdat";
        public string SortOrder { get; set; } = "asc";
    }
}
