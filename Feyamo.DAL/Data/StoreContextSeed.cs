using Feyamo.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Feyamo.DAL.Data
{
    public class StoreContextSeed
    {


        public static async Task SeedAsync(AppDbContext _dbContext)
        {
            if (_dbContext.Set<ApplicationUser>().Count() == 0)
            { 
            var userData = File.ReadAllText("../Feyamo.DAL/Data/DataSeeding/Admin.json");

            var users = JsonSerializer.Deserialize<List<ApplicationUser>>(userData);

            if (users.Count > 0)
            {
                foreach (var item in users)
                {
                    _dbContext.Set<ApplicationUser>().Add(item);
                }
                await _dbContext.SaveChangesAsync();
            }

            }

        }







    }
}
