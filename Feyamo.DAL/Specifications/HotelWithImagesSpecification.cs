using Feyamo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.DAL.Specifications
{
    public class HotelWithImagesSpecification : BaseSpecifications<Hotel>
    {
        public HotelWithImagesSpecification(string? sort, string? search) :base( h=>
               string.IsNullOrEmpty(search) || h.Name.ToLower().Contains(search.ToLower())
            )
        {
            Includes.Add(H=>H.Images);
            Includes.Add(H=>H.reservationHotels);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(h => h.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDesc(h => h.Price);
                        break;

                    default:
                        AddOrderBy(h => h.Name);
                        break;
                }

            }
            else
            { 
                AddOrderBy(h => h.Name);
            }




        }

        public HotelWithImagesSpecification(int id) :base(H => H.Id == id)
        {
            Includes.Add(H => H.Images);
            Includes.Add(H => H.reservationHotels);
        }




    }
}
