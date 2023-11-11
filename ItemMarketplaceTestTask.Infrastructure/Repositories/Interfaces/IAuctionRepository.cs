using ItemMarketplaceTestTask.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
namespace ItemMarketplaceTestTask.Infrastructure.Repositories.Interfaces
{
    public interface IAuctionRepository
    {
        IQueryable<Auction> GetAll();
    }
}
