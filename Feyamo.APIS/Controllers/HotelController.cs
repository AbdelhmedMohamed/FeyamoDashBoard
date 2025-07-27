using AutoMapper;
using DashBoard.PL.ViewModels;
using Feyamo.APIS.DTOs;
using Feyamo.APIS.Errors;
using Feyamo.BLL.ApiRepositories;
using Feyamo.BLL.Interfacies;
using Feyamo.DAL.Models;
using Feyamo.DAL.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Feyamo.APIS.Controllers
{
    
    public class HotelController : BaseApiController
    {
        private readonly IGenericRepoAPI<Hotel> _hotelRepo;
        private readonly IMapper _mapper;

        public HotelController(IGenericRepoAPI<Hotel> hotelRepo ,IMapper mapper )
        {
            _hotelRepo = hotelRepo;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<HotelDto>>> GetHotels(string? sort ,string? search)
        {
            var spec = new HotelWithImagesSpecification(sort,search);

            var hotels = await _hotelRepo.GetAllWithSpecAsync(spec);

            var hotelsDto = _mapper.Map<IReadOnlyList<Hotel>, IReadOnlyList<HotelDto>>(hotels);

            if (hotelsDto == null)
            {
               return NotFound(new ApiRespons(404)); //404
            }
            return Ok(hotelsDto);
        }


        [ProducesResponseType(typeof(HotelDto) , StatusCodes.Status200OK )]
        [ProducesResponseType(typeof(ApiRespons), StatusCodes.Status404NotFound)]

        [HttpGet("by-id")]
        public async Task<ActionResult<HotelDto>> GetById([FromQuery] int id)
        {
            var spec = new HotelWithImagesSpecification(id);

            var hotel = await _hotelRepo.GetWithSpecAsync(spec);

            var hotelDto = _mapper.Map<Hotel, HotelDto>(hotel);

            if (hotelDto == null)
            {
              return  NotFound(new ApiRespons(404)); //404
            }

            return Ok(hotelDto);

        }


      


    }
}
