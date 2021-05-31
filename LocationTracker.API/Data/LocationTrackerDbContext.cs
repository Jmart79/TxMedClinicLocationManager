using LocationTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.API.Data
{
    public class LocationTrackerDbContext : DbContext
    {
        public LocationTrackerDbContext(DbContextOptions<LocationTrackerDbContext> options)
           : base(options)
        {
        }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
