using AutoMapper;
using Feyamo.APIS.DTOs;
using Feyamo.DAL.Models;

namespace Feyamo.APIS.Helpers
{
    public class PlaceImageUrlResolver : IValueResolver<Place, PlaceDto, List<string>>
    {
        private readonly IConfiguration _configuration;

        public PlaceImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<string> Resolve(Place source, PlaceDto destination, List<string> destMember, ResolutionContext context)
        {
            var baseUrl = _configuration["AppBaseUrl"];

            if (source.Images != null && source.Images.Any())
            {
                return source.Images
                    .Select(img => $"{baseUrl}/Files/PlaceImages/{img.ImageName}")
                    .ToList();





            }

            return new List<string>();
        }
    
    }
}
