using AutoMapper;
using Feyamo.APIS.DTOs;
using Feyamo.APIS.Errors;
using Feyamo.BLL.ApiRepositories;
using Feyamo.DAL.Models;
using Feyamo.DAL.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Feyamo.APIS.Controllers
{
    
    public class PlaceController : BaseApiController
    {
        private readonly IGenericRepoAPI<Place> _placeRepo;
        private readonly IMapper _mapper;

        public PlaceController(IGenericRepoAPI<Place> placeRepo , IMapper mapper)
        {
            _placeRepo = placeRepo;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<PlaceDto>>> GetPlaces(string? sort, string? search)
        {
            var spec = new PlaceWithImagesSpecification(sort,search);

            var places = await _placeRepo.GetAllWithSpecAsync(spec);

            var placesDto = _mapper.Map<IReadOnlyList<Place>,IReadOnlyList<PlaceDto>>(places);

            if (placesDto == null)
            {
                return NotFound(new ApiRespons(404)); //404
            }
            return Ok(placesDto);
        }


        [ProducesResponseType(typeof(PlaceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiRespons), StatusCodes.Status404NotFound)]

        [HttpGet("by-id")]
        public async Task<ActionResult<PlaceDto>> GetById([FromQuery] int id)
        {
            var spec = new PlaceWithImagesSpecification(id);

            var place = await _placeRepo.GetWithSpecAsync(spec);

            var placeDto = _mapper.Map<Place,PlaceDto>(place);

            if (placeDto == null)
            {
                return NotFound(new ApiRespons(404)); //404
            }

            return Ok(placeDto);

        }



    }
}
