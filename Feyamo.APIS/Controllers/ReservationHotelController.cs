using AutoMapper;
using Feyamo.APIS.DTOs;
using Feyamo.APIS.Errors;
using Feyamo.BLL.ApiRepositories;
using Feyamo.BLL.Interfacies;
using Feyamo.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Feyamo.APIS.Controllers
{
    
    public class ReservationHotelController : BaseApiController
    {
        private readonly IReservationHotelRepoAPI _reservationHotelRepo;
        private readonly IMapper _mapper;

        public ReservationHotelController(IReservationHotelRepoAPI reservationHotelRepo,IMapper mapper)
        {
            _reservationHotelRepo = reservationHotelRepo;
            _mapper = mapper;
        }



        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<ReservationHotelDto>>> GetAll()
        {
            var reservations = await _reservationHotelRepo.GetAllReservationHotelAsync();

            if (reservations == null)
            {
                return NotFound(new ApiRespons(404)); //404
            }

            var reservationDto = _mapper.Map<IReadOnlyList<ReservationHotel>, IReadOnlyList<ReservationHotelDto>>(reservations);

            return Ok(reservationDto);
        }





        [HttpGet("by-id")]

        public async Task<ActionResult<ReservationHotelDto>> GetReservationById([FromQuery] int id)
        {
            var reservation = await  _reservationHotelRepo.GetReservationHotelAsync(id);

            if (reservation == null)
            {
                return NotFound(new ApiRespons(404)); //404
            }

            var reservationDto = _mapper.Map<ReservationHotel, ReservationHotelDto>(reservation);

            return Ok(reservationDto);

        }


        [HttpPost]
        public async Task<ActionResult<ReservationHotel>> AddReservation(ReservationHotelDto reservationHotelDto)
        {
      
                var reservation = _mapper.Map<ReservationHotelDto, ReservationHotel>(reservationHotelDto);

            reservation = await _reservationHotelRepo.AddAsync(reservation);

                if (reservation == null)
                {
                    return NotFound(new ApiRespons(400));
                }

                return Ok(reservation);           
           
        }



        [HttpPut]
        public async Task<ActionResult<ReservationHotel>> UpdateReservation(ReservationHotelDtoId reservationHotelDto)
        {
            var reservation = _mapper.Map<ReservationHotelDtoId, ReservationHotel>(reservationHotelDto);

             reservation = await _reservationHotelRepo.UpdateAsync(reservation);

            if (reservation == null)
            {
                return NotFound(new ApiRespons(404)); 
            }

            return Ok(reservationHotelDto);
        }



        [HttpDelete]

        public async Task<ActionResult<string>> DeleteReservation([FromQuery]int id)
        {
             var reservation =  await _reservationHotelRepo.Delete(id);

            if (reservation == null)
            {
                return NotFound(new ApiRespons(404));
            }
            return   Ok("Deleted successfully!");
        }



    }
}
