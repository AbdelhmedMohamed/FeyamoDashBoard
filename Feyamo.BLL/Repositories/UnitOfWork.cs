using Feyamo.BLL.ApiRepositories;
using Feyamo.BLL.Interfacies;
using Feyamo.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _DbContext;

        public UnitOfWork(AppDbContext appDbContext )
        {
            _DbContext = appDbContext;

            HotelRepository = new HotelRepository(_DbContext);
            placeReopsitory = new PlaceReopsitory(_DbContext);
            hotelImages = new HotelImagesRepo(_DbContext);
            PlaceImages = new PlaceImagesRepo(_DbContext);
            //ReservationHotelRepoAPI = new ReservationHotelRepoAPI(_DbContext);

        }

        public IHotelRepository HotelRepository { get ; set; }
        public IPlaceReopsitory placeReopsitory { get ; set ; }

        public IHotelImages hotelImages { get; set; }
        public IPlaceImages PlaceImages { get ; set ; }
        //public IReservationHotelRepoAPI ReservationHotelRepoAPI { get ; set ; }

        public int Complete()
        {
          return  _DbContext.SaveChanges();
        }


        public void Dispose()
        {
            _DbContext.Dispose();
        }

    }
}
