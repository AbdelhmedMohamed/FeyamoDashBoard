using Feyamo.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.DAL.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> 
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Fluent API
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>()
                        .ToTable("Roles");

            modelBuilder.Entity<IdentityUser>()
                        .ToTable("Users");


        }


        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<ReservationHotel> ReservationHotels { get; set; }


       




    }
}
