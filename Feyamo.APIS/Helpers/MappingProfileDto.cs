using AutoMapper;
using Feyamo.APIS.DTOs;
using Feyamo.DAL.Models;

namespace Feyamo.APIS.Helpers
{
    public class MappingProfileDto :Profile
    {
        public MappingProfileDto()
        {

            CreateMap<Hotel, HotelDto>()

                  .ForMember(d => d.ImageNames,
                 opt => opt.MapFrom<HotelImageUrlResolver>());

            //.ForMember(dest => dest.ReservationHotelIds,
                       //opt => opt.MapFrom(src => src.reservationHotels.Select(r => r.Id)));




            CreateMap<Place, PlaceDto>()
                  .ForMember(d => d.ImageNames,
                  opt => opt.MapFrom<PlaceImageUrlResolver>());


            CreateMap<ReservationHotelDtoId, ReservationHotel>().ReverseMap();

               CreateMap<ReservationHotelDto, ReservationHotel>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                   .ReverseMap();





        }


    }
}
