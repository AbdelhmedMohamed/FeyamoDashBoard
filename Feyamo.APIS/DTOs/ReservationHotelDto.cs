using Feyamo.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feyamo.APIS.DTOs
{
    public class ReservationHotelDto
    {


        //public int Id { get; set; }

        [Required(ErrorMessage = "Hotelt Name is required")]
        public string HoteltName { get; set; }

        [Required(ErrorMessage = "Tourist Name is required")]

        public string TouristName { get; set; }

        [Required(ErrorMessage = "Number Of Days is required")]
        [Range(1,int.MaxValue,ErrorMessage = "Number Of Days must be at laest one!")]
        public int NumberOfDays { get; set; }

        [Required(ErrorMessage = "Booking Date is required")]

        public DateTime BookingDate { get; set; }


        [Required(ErrorMessage = "Hotel Id is required")]
        public int HotelId { get; set; } //FK




    }
}
