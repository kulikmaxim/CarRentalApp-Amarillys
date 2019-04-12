using DAL.Extensions;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class CarRentalAppContext : DbContext
    {
        public CarRentalAppContext(DbContextOptions<CarRentalAppContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
