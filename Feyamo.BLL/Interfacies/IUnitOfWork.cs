using Feyamo.BLL.ApiRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.BLL.Interfacies
{
    public interface IUnitOfWork : IDisposable
    {

        public IHotelRepository HotelRepository { get; set; }

        public IPlaceReopsitory placeReopsitory { get; set; }

       // public IReservationHotelRepoAPI ReservationHotelRepoAPI { get; set; }

        public IHotelImages hotelImages { get; set; }


        public IPlaceImages PlaceImages { get; set; }


        int Complete();


    }
}
