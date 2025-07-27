using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Feyamo.DAL.Models
{
    public class Hotel
    {
        public int Id { get; set; } //PK
         

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        //navigation property[many]

        [InverseProperty(nameof(Models.HotelImages.Hotel))]

        public ICollection<HotelImages> Images { get; set; } = new List<HotelImages>();


        //navigation property[many]

        [InverseProperty(nameof(Models.ReservationHotel.Hotel))]

        public ICollection<ReservationHotel> reservationHotels  { get; set; } = new List<ReservationHotel>();



    }
}
