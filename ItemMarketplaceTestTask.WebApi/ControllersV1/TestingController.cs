using ItemMarketplaceTestTask.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItemMarketplaceTestTask.WebApi.ControllersV1
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0", Deprecated = true)]
    public class TestingController : ControllerBase
    {
        private readonly ILogger<TestingController> _logger;
        private readonly ITestingService _testingService;

        public TestingController(ILogger<TestingController> logger,
            ITestingService testingService)
        {
            _logger = logger;
            _testingService = testingService;
        }

        [HttpPost("generate/test-item-data")]
        public async Task<IActionResult> GenerateTestItemDataAsync([FromBody] int count)
        {
            _logger.LogDebug($"{nameof(GenerateTestItemDataAsync)} request.");

            var result = await _testingService.GenerateTestItemDataAsync(count);

            _logger.LogDebug($"{nameof(GenerateTestItemDataAsync)} Current items count - {result}.");

            return Ok(result);
        }

        [HttpPost("generate/test-auction-data")]
        public async Task<IActionResult> GenerateTestAuctionDataAsync([FromBody] int count)
        {
            _logger.LogDebug($"{nameof(GenerateTestAuctionDataAsync)} request.");

            var result = await _testingService.GenerateTestAuctionDataAsync(count);

            _logger.LogDebug($"{nameof(GenerateTestAuctionDataAsync)} Current auctions count - {result}.");

            return Ok(result);
        }
    }
}
