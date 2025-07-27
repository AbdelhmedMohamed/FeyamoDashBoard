using Feyamo.DAL.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DashBoard.PL.ViewModels
{
    public class PlaceViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Code Is Required!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name Is Required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price Is Required!")]
        [DataType(DataType.Currency)]
        public int Price { get; set; }


        //public string ImageName { get; set; }

        public ICollection<PlaceImages> Images { get; set; } = new List<PlaceImages>();

        //[Required(ErrorMessage = "Image Is Required!")]
        public new List<IFormFile> ImagesName { get; set; }


        public List<string> ImageNames { get; set; }





    }
}
