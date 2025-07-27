using Feyamo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.BLL.Interfacies
{
    public interface IPlaceReopsitory : IGenericRepository<Place>
    {


        public Place GetByIdWithImages(int id);


    }
}
