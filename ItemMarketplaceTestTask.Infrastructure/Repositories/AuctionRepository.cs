using ItemMarketplaceTestTask.Infrastructure.Repositories.Interfaces;
using ItemMarketplaceTestTask.Model.Entities;
using MarketplaceTestTask.Infrastructure;
using Microsoft.EntityFrameworkCore;

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
    }
}
