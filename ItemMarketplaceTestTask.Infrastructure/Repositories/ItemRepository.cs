using ItemMarketplaceTestTask.Infrastructure.Repositories.Interfaces;
using ItemMarketplaceTestTask.Model.Entities;
using MarketplaceTestTask.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ItemMarketplaceTestTask.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private AppDbContext _dbContext;
        private DbSet<Item> _dbSet => _dbContext.Set<Item>();

        public ItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Item Add(Item item)
        {
            EntityEntry entityEntry = _dbSet.Add(item);
            return (Item)entityEntry.Entity;
        }

        public async Task AddRangeAsync(List<Item> auctions)
        {
            await _dbSet.AddRangeAsync(auctions);
        }

        public IQueryable<Item> GetAll()
        {
            return _dbSet;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
