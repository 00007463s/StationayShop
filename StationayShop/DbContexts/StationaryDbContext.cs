using Microsoft.EntityFrameworkCore;
using StationayShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationayShop.DbContexts
{
    public class StationaryDbContext : DbContext
    {
        public StationaryDbContext(DbContextOptions<StationaryDbContext> options) : base(options)
        {

        }
        public DbSet<Stationary> Stationaries { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
