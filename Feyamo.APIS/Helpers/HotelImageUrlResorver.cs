using AutoMapper;
using Feyamo.APIS.DTOs;
using Feyamo.DAL.Models;
using Microsoft.Extensions.Configuration;

namespace Feyamo.APIS.Helpers
{
    public class HotelImageUrlResolver : IValueResolver<Hotel, HotelDto, List<string>>
    {
        private readonly IConfiguration _configuration;

        public HotelImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<string> Resolve(Hotel source, HotelDto destination, List<string> destMember, ResolutionContext context)
        {
            var baseUrl = _configuration["AppBaseUrl"];

            if (source.Images != null && source.Images.Any())
            {
                return source.Images
                    .Select(img => $"{baseUrl}/Files/HotelImages/{img.ImageName}")
                    .ToList();


          


            }

            return new List<string>();
        }
    }
}
