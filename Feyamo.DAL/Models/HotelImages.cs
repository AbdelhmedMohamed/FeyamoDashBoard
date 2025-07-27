using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.DAL.Models
{
    public class HotelImages
    {
        public int Id { get; set; } //PK


        [Required]
        public string ImageName { get; set; }

        //navigation property[one]

        [InverseProperty(nameof(Models.Hotel.Images))]  
        public Hotel Hotel { get; set; }

        public int? HotelId { get; set; } //FK




    }
}
