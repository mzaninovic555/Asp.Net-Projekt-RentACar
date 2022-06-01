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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Store> stores = new List<Store>
            {
                new Store{ ID = 1, Address = "Vukovarska 41", PhoneNumber = "01 3885 777", Email = "rentacar-zagreb@gmail.com", OpenFrom = TimeSpan.Parse("06:00"), OpenTo = TimeSpan.Parse("17:00"), CityID = 1 },
                new Store{ ID = 2, Address = "Zvonimirova 20 A", PhoneNumber = "01 2314 019 ", Email = "rentacar-rijeka@gmail.com", OpenFrom = TimeSpan.Parse("06:00"), OpenTo = TimeSpan.Parse("16:00"), CityID = 2 },
                new Store{ ID = 3, Address = "Vukovarska 182", PhoneNumber = "01 3310 050 ", Email = "rentacar-split@gmail.com", OpenFrom = TimeSpan.Parse("08:00"), OpenTo = TimeSpan.Parse("15:00"), CityID = 3 },
                new Store{ ID = 4, Address = "Sinjska 15", PhoneNumber = "01 4552 590 ", Email = "rentacar-dubrovnik@gmail.com", OpenFrom = TimeSpan.Parse("07:00"), OpenTo = TimeSpan.Parse("14:00"), CityID = 4 },
                new Store{ ID = 5, Address = "27 E 22nd St, NY 10010", PhoneNumber = "347 3917 724", Email = "rentacar-newyork@gmail.com", OpenFrom = TimeSpan.Parse("05:00"), OpenTo = TimeSpan.Parse("22:00"), CityID = 5 },
                new Store{ ID = 6, Address = "9800 S Sepulveda Blvd, CA 90045", PhoneNumber = "916 955 0339", Email = "rentacar-losangeles@gmail.com", OpenFrom = TimeSpan.Parse("06:00"), OpenTo = TimeSpan.Parse("21:00"), CityID = 6 },
                new Store{ ID = 7, Address = "923 16th St NW, DC 20006", PhoneNumber = "202 714 2570", Email = "rentacar-washingtondc@gmail.com", OpenFrom = TimeSpan.Parse("08:00"), OpenTo = TimeSpan.Parse("20:00"), CityID = 7 }
            };

            List<City> citiesCroatia = new List<City>
            {
                new City { ID = 1, Name = "Zagreb", PostalCode = 10000, CountryID = 1 },
                new City { ID = 2, Name = "Rijeka", PostalCode = 51000, CountryID = 1 },
                new City { ID = 3, Name = "Split", PostalCode = 21000, CountryID = 1 },
                new City { ID = 4, Name = "Dubrovnik", PostalCode = 20000, CountryID = 1 }
            };

            List<City> citiesUSA = new List<City>
            {
                new City { ID = 5, Name = "New York", PostalCode = 11368, CountryID = 2 },
                new City { ID = 6, Name = "Los Angeles", PostalCode = 90011, CountryID = 2 },
                new City { ID = 7, Name = "Washington D.C.", PostalCode = 20011, CountryID = 2 }
            };

            List<Country> countries = new List<Country>
            {
                new Country { ID = 1, Name = "Hrvatska" },
                new Country { ID = 2, Name = "United States" },
            };

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<Store>().HasData(stores);
            modelBuilder.Entity<City>().HasData(citiesCroatia);
            modelBuilder.Entity<City>().HasData(citiesUSA);
        }
    }
}
