using ItemMarketplaceTestTask.Model.Entities;

namespace ItemMarketplaceTestTask.Infrastructure.Repositories.Interfaces
{
    public interface IAuctionRepository
    {
        IQueryable<Auction> GetAll();
        Auction Add(Auction auction);
        Task AddRangeAsync(List<Auction> auctions);
        Task SaveChangesAsync();
        void ClearCache();
    }
}
