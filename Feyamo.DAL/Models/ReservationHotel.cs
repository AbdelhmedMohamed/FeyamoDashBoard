using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.DAL.Models
{
    public class ReservationHotel
    {
        public int Id { get; set; }

        [Required]
        public string HoteltName { get; set; }
        [Required]
        public string TouristName { get; set; }

        public int NumberOfDays { get; set; }

        public DateTime BookingDate { get; set; }


        //navigation property[one]
        [InverseProperty(nameof(Models.Hotel.reservationHotels))]
        public Hotel Hotel { get; set; }


        public int HotelId { get; set; } //FK



    }
}
