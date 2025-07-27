using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.DAL.Models
{
    public class PlaceImages
    {

        public int Id { get; set; } //PK


        [Required]
        public string ImageName { get; set; }

        //navigation property[one]

        [InverseProperty(nameof(Models.Place.Images))]
        public Place Place { get; set; }

        public int? PlaceId { get; set; } //FK


    }
}
