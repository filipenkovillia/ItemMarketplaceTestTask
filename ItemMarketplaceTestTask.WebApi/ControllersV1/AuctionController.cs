using ItemMarketplaceTestTask.Model.Request;
using ItemMarketplaceTestTask.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItemMarketplaceTestTask.WebApi.ControllersV1
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    public class AuctionController : ControllerBase
    {
        private readonly ILogger<AuctionController> _logger;
        private readonly IAuctionService _auctionService;

        public AuctionController(ILogger<AuctionController> logger, 
            IAuctionService auctionService)
        {
            _logger = logger;
            _auctionService = auctionService;
        }

        [HttpGet("auctions")]
        public async Task<IActionResult> GetAuctionsAsync([FromQuery] AuctionRequest request)
        {
            _logger.LogDebug($"{nameof(GetAuctionsAsync)} request.");

            var result = await _auctionService.GetAuctionsByFiltersAsync(request);

            _logger.LogDebug($"{nameof(GetAuctionsAsync)} returned {result.Count} auctions as a result.");

            return Ok(result);
        }

        [HttpGet("auctions/{id}")]
        public async Task<IActionResult> GetAuctionByIdAsync([FromRoute] int id)
        {
            _logger.LogDebug($"{nameof(GetAuctionByIdAsync)} request: id = {id}.");

            var result = await _auctionService.GetAuctionByIdAsync(id);

            return Ok(result);
        }
    }
}
