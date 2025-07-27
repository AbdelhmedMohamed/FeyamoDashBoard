using Feyamo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.DAL.Data.Configurations
{
    internal class HotelConfigurations : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            //Fluent APIS
            builder.HasMany(H => H.Images)
                   .WithOne(I => I.Hotel)
                   .OnDelete(DeleteBehavior.Cascade);



            builder.HasMany(H => H.reservationHotels)
                    .WithOne(R => R.Hotel)
                    .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
