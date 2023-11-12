using ItemMarketplaceTestTask.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMarketplaceTestTask.Infrastructure.Repositories.Interfaces
{
    public interface IItemRepository
    {
        IQueryable<Item> GetAll();
        Item Add(Item item);
        Task AddRangeAsync(List<Item> auctions);
        Task SaveChangesAsync();
    }
}
