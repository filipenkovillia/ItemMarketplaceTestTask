using ItemMarketplaceTestTask.Infrastructure.Repositories.Interfaces;
using ItemMarketplaceTestTask.Model.Entities;
using ItemMarketplaceTestTask.Model.Enums;
using ItemMarketplaceTestTask.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMarketplaceTestTask.Service
{
    public class TestingService : ITestingService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IAuctionRepository _auctionRepository;

        public TestingService(IItemRepository itemRepository, 
            IAuctionRepository auctionRepository) 
        { 
            _itemRepository = itemRepository;
            _auctionRepository = auctionRepository;
        }

        public async Task<int> GenerateTestItemDataAsync(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var item = new Item
                {
                    Name = "Item" + i,
                    Description = "Description for Item " + i,
                    Metadata = "Metadata for Item " + i
                };

                _itemRepository.Add(item);

                if (i % 1000 == 0)
                {
                    await _itemRepository.SaveChangesAsync();
                }
            }

            await _itemRepository.SaveChangesAsync();

            var currentItemCount = await _itemRepository
                .GetAll()
                .AsNoTracking()
                .CountAsync();

            return currentItemCount;
        }

        public async Task<int> GenerateTestAuctionDataAsync(int count)
        {
            var itemMaxId = await _itemRepository
                .GetAll()
                .AsNoTracking()
                .Select(x => x.Id)
                .MaxAsync();

            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var itemId = random.Next(itemMaxId + 1);

                var isValidItemId = await _itemRepository
                    .GetAll()
                    .AsNoTracking()
                    .AnyAsync(x => x.Id == itemId);

                if (isValidItemId)
                {
                    var status = (AuctionStatus)random.Next(0, 4);

                    DateTime? finishedAt = status == AuctionStatus.Finished
                        ? DateTime.UtcNow.AddMinutes(random.Next(1, 10000)) 
                        : null;

                    _auctionRepository.Add(new Auction
                    {
                        ItemId = itemId,
                        CreatedAt = finishedAt.HasValue
                            ? finishedAt.Value.AddMinutes(-random.Next(1, 200))
                            : DateTime.UtcNow.AddMinutes(-random.Next(1, 10000)),
                        FinishedAt = finishedAt,
                        Price = status == AuctionStatus.Finished
                            ? (decimal)random.NextDouble() * 1000
                            : null,
                        Status = status,
                        Seller = "Seller" + i,
                        Buyer = status == AuctionStatus.Finished
                            ? "Buyer" + i
                            : null
                    });
                }

                if (i % 1000 == 0)
                {
                    await _auctionRepository.SaveChangesAsync();
                    _auctionRepository.ClearCache();
                }
            }

            await _auctionRepository.SaveChangesAsync();
            _auctionRepository.ClearCache();

            var currentAuctionCount = await _auctionRepository
                .GetAll()
                .AsNoTracking()
                .CountAsync();

            return currentAuctionCount;
        }
    }
}
