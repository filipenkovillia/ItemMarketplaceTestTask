using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMarketplaceTestTask.Service.Interfaces
{
    public interface ITestingService
    {
        Task<int> GenerateTestItemDataAsync(int count);
        Task<int> GenerateTestAuctionDataAsync(int count);
    }
}
