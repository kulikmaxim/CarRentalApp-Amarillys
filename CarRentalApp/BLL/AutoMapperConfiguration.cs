using AutoMapper;
using BLL.Models;
using DAL.Models;

namespace BLL
{
    public class AutoMapperConfiguration
    {
        public IMapper ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Car, CarInfo>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class))
                    .ForMember(dest => dest.Mark, opt => opt.MapFrom(src => src.Mark))
                    .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                    .ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(src => src.RegistrationNumber))
                    .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseYear))
                    .ReverseMap();

                cfg.CreateMap<User, UserInfo>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                    .ForMember(dest => dest.DrivingLicenseNumber, opt => opt.MapFrom(src => src.DrivingLicenseNumber))
                    .ReverseMap();

                cfg.CreateMap<Order, OrderInfo>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId))
                    .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src.Car))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                    .ForMember(dest => dest.RentalBeginDate, opt => opt.MapFrom(src => src.RentalBeginDate))
                    .ForMember(dest => dest.RentalEndDate, opt => opt.MapFrom(src => src.RentalEndDate))
                    .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                    .ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
