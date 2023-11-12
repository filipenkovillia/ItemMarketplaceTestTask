using ItemMarketplaceTestTask.Model.Entities;

namespace ItemMarketplaceTestTask.Infrastructure.Repositories.Interfaces
{
    public interface IAuctionRepository
    {
        IQueryable<Auction> GetAll();
    }
}
