using ItemMarketplaceTestTask.Infrastructure.Repositories.Interfaces;
using ItemMarketplaceTestTask.Model.Entities;
using ItemMarketplaceTestTask.Model.Request;
using ItemMarketplaceTestTask.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using ItemMarketplaceTestTask.Model.DTO;
using AutoMapper;

namespace ItemMarketplaceTestTask.Service
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly ILogger<AuctionService> _logger;
        private readonly IMapper _mapper;

        public AuctionService(IAuctionRepository auctionRepository, 
            ILogger<AuctionService> logger,
            IMapper mapper) 
        { 
            _auctionRepository = auctionRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<Auction>> GetAuctionsByFiltersAsync(AuctionRequest request)
        {
            var auctionsQuery = _auctionRepository
                .GetAll()
                .Include(x => x.Item)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                auctionsQuery = auctionsQuery.Where(x => x.Item.Name.Contains(request.Name));
            }

            if (!string.IsNullOrWhiteSpace(request.Seller))
            {
                auctionsQuery = auctionsQuery.Where(x => x.Seller == request.Seller);
            }

            if (request.Status.HasValue)
            {
                auctionsQuery = auctionsQuery.Where(x => x.Status == request.Status.Value);
            }

            ApplySort(ref auctionsQuery, request.SortKey, request.SortOrder);

            var auctions = await auctionsQuery
                .Skip((request.PageNumber - 1) * request.Limit)
                .Take(request.Limit)
                .ToListAsync();

            return auctions;
        }

        public async Task<List<AuctionDTO>> GetAuctionDTOByFiltersAsync(AuctionRequest request)
        {
            var auctions = await GetAuctionsByFiltersAsync(request);

            return auctions
                .Select(x => _mapper.Map<AuctionDTO>(x))
                .ToList();
        }

        public async Task<Auction> GetAuctionByIdAsync(int id)
        {
            var auction = await _auctionRepository
                .GetAll()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (auction == null)
            {
                var errorMessage = $"{nameof(GetAuctionByIdAsync)} Auction with id = {id} does not exist.";
                _logger.LogError(errorMessage);
                throw new Exception(errorMessage);
            }

            return auction;
        }

        #region Private methods

        private void ApplySort(ref IQueryable<Auction> auctionsQuery, 
            string orderByQueryString, string sortOrder)
        {
            if (!auctionsQuery.Any())
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                auctionsQuery = auctionsQuery.OrderBy(x => x.CreatedAt);
                return;
            }

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Auction).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                {
                    continue;
                }

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos
                    .FirstOrDefault(x => x.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                {
                    continue;
                }

                var sortingOrder = sortOrder == "desc" ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                auctionsQuery = auctionsQuery.OrderBy(x => x.CreatedAt);
                return;
            }

            auctionsQuery = auctionsQuery.OrderBy(orderQuery);
        }

        #endregion
    }
}
