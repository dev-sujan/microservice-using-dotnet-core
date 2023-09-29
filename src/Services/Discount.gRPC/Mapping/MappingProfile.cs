using AutoMapper;
using Discount.gRPC.Models;
using Discount.gRPC.Protos;

namespace Discount.gRPC.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coupon, CouponRequest>().ReverseMap();
        }
    }
}
