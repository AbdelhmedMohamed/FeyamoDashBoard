using Feyamo.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feyamo.APIS.DTOs
{
    public class PlaceDto
    {
        public int Id { get; set; }
       
        public string Code { get; set; }      
        public string Name { get; set; }      
        public int Price { get; set; }

        public List<string> ImageNames { get; set; }
    }
}
