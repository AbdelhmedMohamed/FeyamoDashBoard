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
    public class HotelRepository : GenericRepository<Hotel> ,IHotelRepository
    {
        private readonly AppDbContext _dbContext;

        public HotelRepository(AppDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext; 
        }


        public Hotel GetByIdWithImages(int id)
        {
            return _dbContext.Hotels
                .Include(h => h.Images) 
                .FirstOrDefault(h => h.Id == id);
        }





    }
}
