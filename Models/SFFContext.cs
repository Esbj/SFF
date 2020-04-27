using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SFF.Models
{
    public class SFFContext : DbContext
    {
        public SFFContext(DbContextOptions<SFFContext> options) : base(options)
        {}
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Assosiation> Assosiations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rental>Rentals { get; set; }
    }
}