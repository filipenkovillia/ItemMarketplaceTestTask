using AutoMapper;
using ItemMarketplaceTestTask.Model.DTO;
using ItemMarketplaceTestTask.Model.Entities;

namespace ItemMarketplaceTestTask.WebApi
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<Auction, AuctionDTO>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.Name));
        }
    }
}
