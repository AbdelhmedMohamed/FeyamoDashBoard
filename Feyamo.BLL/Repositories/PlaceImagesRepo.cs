using Feyamo.BLL.Interfacies;
using Feyamo.DAL.Data;
using Feyamo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.BLL.Repositories
{
    public class PlaceImagesRepo : GenericRepository<PlaceImages>, IPlaceImages
    {
        private readonly AppDbContext _dbContext;

        public PlaceImagesRepo(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
