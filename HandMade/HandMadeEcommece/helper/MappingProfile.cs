global using AutoMapper;
using HandMadeEcommece.Models;
using HandMadeEcommece.Models.Data;

namespace HandMadeEcommece.helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Admin, RegisterAdminDto>().ReverseMap().ForMember(e =>  e.Id, opt => opt.Ignore()).ForMember(e => e.Image, opt => opt.Ignore());
            CreateMap<User, UserDto>().ReverseMap().ForMember(e => e.Id, opt => opt.Ignore()).ForMember(e => e.Image, opt => opt.Ignore());
            CreateMap<Brand, BrandDto>().ReverseMap().ForMember(e => e.Id, opt => opt.Ignore()).ForMember(e => e.Logo, opt => opt.Ignore());
            CreateMap<Product, ProductDto>().ReverseMap().ForMember(e => e.Id, opt => opt.Ignore()).ForMember(e => e.ThumbImage, opt => opt.Ignore()).ForMember(e=>e.UpdatedAt,opt=>opt.Ignore()).ForMember(e=>e.CreatedAt,opt=>opt.Ignore());
            CreateMap<PusherSetting, PusherSettingDto>().ReverseMap();
            CreateMap<Coupon, CouponDto>().ReverseMap().ForMember(e => e.Status,opt=>opt.Ignore());
        }
    }
}
