using Feyamo.BLL.Interfacies;
using Feyamo.DAL.Models;
using Feyamo.DAL.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.BLL.ApiRepositories
{
    public interface IReservationHotelRepoAPI 
    {
       Task<IReadOnlyList<ReservationHotel>> GetAllReservationHotelAsync();

       Task<ReservationHotel>  GetReservationHotelAsync(int id);

       Task<ReservationHotel> AddAsync(ReservationHotel reservationHotel);

        Task<ReservationHotel> UpdateAsync(ReservationHotel reservationHotel);

        Task<ReservationHotel> Delete(int id);


    }
}
