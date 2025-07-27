using AutoMapper;
using DashBoard.PL.ViewModels;
using Feyamo.DAL.Models;
using System.Linq;

namespace DashBoard.PL.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<HotelViewModel, Hotel>().ReverseMap();
            //CreateMap<PlaceViewModel, Place>().ReverseMap();

            CreateMap<HotelViewModel, Hotel>().ReverseMap()
    .ForMember(dest => dest.ImageNames,
               opt => opt.MapFrom(src => src.Images.Select(img => img.ImageName).ToList()));



            CreateMap<PlaceViewModel, Place>().ReverseMap()
   .ForMember(dest => dest.ImageNames,
              opt => opt.MapFrom(src => src.Images.Select(img => img.ImageName).ToList()));




        }



    }
}
