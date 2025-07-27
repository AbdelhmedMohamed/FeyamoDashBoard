using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.DAL.Models
{
    public class Place
    {
        public int Id { get; set; } //PK


        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]

        [DataType(DataType.Currency)]
        public int Price { get; set; }


        //navigation property[many]

        [InverseProperty(nameof(Models.PlaceImages.Place))]

        public ICollection<PlaceImages> Images { get; set; } = new List<PlaceImages>();


    }
}
