using ItemMarketplaceTestTask.Model.DTO;
using ItemMarketplaceTestTask.Model.Entities;
using ItemMarketplaceTestTask.Model.Request;

namespace ItemMarketplaceTestTask.Service.Interfaces
{
    public interface IAuctionService
    {
        Task<List<Auction>> GetAuctionsByFiltersAsync(AuctionRequest request);
        Task<List<AuctionDTO>> GetAuctionDTOByFiltersAsync(AuctionRequest request);
        Task<Auction> GetAuctionByIdAsync(int id);
    }
}
