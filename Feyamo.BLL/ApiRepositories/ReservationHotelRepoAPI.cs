using Feyamo.BLL.Repositories;
using Feyamo.DAL.Data;
using Feyamo.DAL.Models;
using Feyamo.DAL.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Feyamo.BLL.ApiRepositories
{
    public class ReservationHotelRepoAPI : IReservationHotelRepoAPI
    {
        private readonly AppDbContext _dbContext;

        public ReservationHotelRepoAPI(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<ReservationHotel> AddAsync(ReservationHotel reservationHotel)
        {
             _dbContext.Add(reservationHotel);
            var count = _dbContext.SaveChanges();
            if (count == 0)
            {
                return null;
            }

            return reservationHotel;
        }

        public async Task<ReservationHotel> Delete(int id)
        {
            var reservation = _dbContext.Set<ReservationHotel>().Find(id);

            if (reservation == null) return null;

            _dbContext.Remove(reservation);

            var count = _dbContext.SaveChanges();
            if (count == 0)
            {
                return null;
            }

            return reservation;

        }

        public async Task<IReadOnlyList<ReservationHotel>> GetAllReservationHotelAsync()
        {
            return await _dbContext.Set<ReservationHotel>().ToListAsync();
        }

        //public async Task<ReservationHotel> GetReservationHotelAsync(int id)
        //{
        //  var reservation = _dbContext.Set<ReservationHotel>().Find(id);

        //    if (reservation == null) return null ;

        //    return reservation;
        //}

        public async Task<ReservationHotel> GetReservationHotelAsync(int id)
        {
            var reservation = await _dbContext.Set<ReservationHotel>()
                                              .AsNoTracking()
                                              .FirstOrDefaultAsync(r => r.Id == id);

            return reservation;
        }


        public async Task<ReservationHotel> UpdateAsync(ReservationHotel reservationHotel)
        {

            var trackedEntity = await _dbContext.Set<ReservationHotel>()
                                        .FirstOrDefaultAsync(r => r.Id == reservationHotel.Id);

            if (trackedEntity is null)
                return null;

            
            _dbContext.Entry(trackedEntity).CurrentValues.SetValues(reservationHotel);

            var count = await _dbContext.SaveChangesAsync();

            if (count == 0)
                return null;

            return trackedEntity;


            //var flge = _dbContext.Set<ReservationHotel>().Find(reservationHotel.Id);

            // if (flge is null) return null;

            // _dbContext.Update(reservationHotel);
            // var count = _dbContext.SaveChanges();
            // if (count == 0)
            // {
            //     return null;
            // }

            // return reservationHotel;

        }
    }
}
