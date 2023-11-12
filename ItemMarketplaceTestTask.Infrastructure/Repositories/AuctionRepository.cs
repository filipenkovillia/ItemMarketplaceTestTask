using ItemMarketplaceTestTask.Infrastructure.Repositories.Interfaces;
using ItemMarketplaceTestTask.Model.Entities;
using MarketplaceTestTask.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ItemMarketplaceTestTask.Infrastructure.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private AppDbContext _dbContext;
        private DbSet<Auction> _dbSet => _dbContext.Set<Auction>();

        public AuctionRepository(AppDbContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public IQueryable<Auction> GetAll()
        {
            return _dbSet;
        }

        public Auction Add(Auction auction)
        {
            EntityEntry entityEntry = _dbSet.Add(auction);
            return (Auction)entityEntry.Entity;
        }

        public async Task AddRangeAsync(List<Auction> auctions)
        {
            await _dbSet.AddRangeAsync(auctions);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void ClearCache()
        {
            _dbContext.ChangeTracker.Clear();
        }
    }
}
