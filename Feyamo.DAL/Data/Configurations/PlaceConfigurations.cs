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
    public class PlaceConfigurations : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            //Fluent APIS
            builder.HasMany(H => H.Images)
                   .WithOne(I => I.Place)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
