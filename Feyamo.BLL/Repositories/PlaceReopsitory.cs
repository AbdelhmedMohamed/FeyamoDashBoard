using Feyamo.BLL.Interfacies;
using Feyamo.DAL.Data;
using Feyamo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.BLL.Repositories
{
    public class PlaceReopsitory : GenericRepository<Place> ,IPlaceReopsitory
    {
        private readonly AppDbContext _dbContext;

        public PlaceReopsitory(AppDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Place GetByIdWithImages(int id)
        {
            return _dbContext.Places
                .Include(h => h.Images)
                .FirstOrDefault(h => h.Id == id);
        }
    }
}
