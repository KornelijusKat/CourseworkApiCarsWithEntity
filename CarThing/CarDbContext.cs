using CarThing.CarClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarThing
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {

        }
    }
}
