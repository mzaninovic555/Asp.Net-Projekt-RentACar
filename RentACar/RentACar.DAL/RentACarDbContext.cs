using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar.Model;

namespace RentACar.DAL
{
    public class RentACarDbContext : IdentityDbContext<AppUser>
    {
        public RentACarDbContext(DbContextOptions<RentACarDbContext> options) : base(options)
        { 
        
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
