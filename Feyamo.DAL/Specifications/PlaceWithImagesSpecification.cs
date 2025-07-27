using Feyamo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.DAL.Specifications
{
    public class PlaceWithImagesSpecification: BaseSpecifications<Place>
    {
        public PlaceWithImagesSpecification(string? sort, string? search) : base(p=>
            string.IsNullOrEmpty(search) || p.Name.ToLower().Contains(search.ToLower())
        )
    {
        Includes.Add(H => H.Images);

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

        public PlaceWithImagesSpecification(int id) : base(P => P.Id == id)
    {
        Includes.Add(H => H.Images);
        
    }

}
}
