using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NationalParkDemo.Models;
using NationalParkDemo.Models.Dtos;

namespace NationalParkDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<NationalPark> NationalParks { get; set; }
    }
}
