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

            List<Brand> brands = new List<Brand>
            {
                new Brand { Id = 1, Name = "Volkswagen" },
                new Brand { Id = 2, Name = "Toyota" },
                new Brand { Id = 3, Name = "Tesla" },
                new Brand { Id = 4, Name = "Mercedes" },
                new Brand { Id = 5, Name = "Skoda" },
                new Brand { Id = 6, Name = "Honda" }
            };

            List<Car> cars = new List<Car>
            {
                new Car { ID = 1, Model = "Golf", 
                    PictureURL = "https://www.carparisonleasing.co.uk/media/responsive/blog_detail_image-1170/cc-uploads/24f6f155/volkswagen%20golf%20r.jpeg",
                    SeatCount = 4,
                    ProductionYear = 2020,
                    IsManual = true,
                    HasBluetooth = true,
                    HasParkingSensors = true,
                    IsElectric = false,
                    HasGps = false,
                    BrandID = 1
                },
                new Car { ID = 2, Model = "Prius", 
                    PictureURL = "https://www.autotrader.com/wp-content/uploads/2021/06/2022-toyota-prius-prime-front-right-side.jpg",
                    SeatCount = 5,
                    ProductionYear = 2022,
                    IsManual = false,
                    HasBluetooth = true,
                    HasParkingSensors = true,
                    IsElectric = true,
                    HasGps = true,
                    BrandID = 2
                },
                new Car { ID = 3, Model = "Civic", 
                    PictureURL = "https://www.oktan.hr/wp-content/uploads/2017/09/honda-civic-2017.jpg",
                    SeatCount = 4,
                    ProductionYear = 2017,
                    IsManual = true,
                    HasBluetooth = true,
                    HasParkingSensors = false,
                    IsElectric = false,
                    HasGps = false,
                    BrandID = 6
                },
                new Car { ID = 4, Model = "Model X", 
                    PictureURL = "https://media.wired.co.uk/photos/606d9b03dbc4c121710a3d36/16:9/w_2560%2Cc_limit/tesla1.jpg",
                    SeatCount = 4,
                    ProductionYear = 2016,
                    IsManual = false,
                    HasBluetooth = true,
                    HasParkingSensors = true,
                    IsElectric = true,
                    HasGps = true,
                    BrandID = 3
                },
                new Car { ID = 5, Model = "C class", 
                    PictureURL = "https://www.topgear.com/sites/default/files/cars-car/carousel/2018/06/18c0437_004.jpg",
                    SeatCount = 4,
                    ProductionYear = 2021,
                    IsManual = true,
                    HasBluetooth = true,
                    HasParkingSensors = true,
                    IsElectric = false,
                    HasGps = true,
                    BrandID = 4
                },
                new Car { ID = 6, Model = "Enyaq iV", 
                    PictureURL = "https://static1.hotcarsimages.com/wordpress/wp-content/uploads/2021/10/Skoda-Enyaq-iV-3.jpg?q=50&fit=crop&w=750&dpr=1.5",
                    SeatCount = 7,
                    ProductionYear = 2020,
                    IsManual = false,
                    HasBluetooth = true,
                    HasParkingSensors = true,
                    IsElectric = true,
                    HasGps = false,
                    BrandID = 5
                },
                new Car { ID = 7, Model = "Octavia", 
                    PictureURL = "https://cdn-hr.skoda.at/media/Theme_UIElement_Image_Small_Component.Theme_UIElement_Slideshow_Item_Image_Component/5767-86119-162082-162083-image-small/dh-991-400692/b3c3338d/1647894440/skoda-octavia-sportline-m62-exterior-01.jpg",
                    SeatCount = 4,
                    ProductionYear = 2022,
                    IsManual = true,
                    HasBluetooth = true,
                    HasParkingSensors = true,
                    IsElectric = false,
                    HasGps = true,
                    BrandID = 5
                }
            };

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<Store>().HasData(stores);
            modelBuilder.Entity<City>().HasData(citiesCroatia);
            modelBuilder.Entity<City>().HasData(citiesUSA);
            modelBuilder.Entity<Brand>().HasData(brands);
            modelBuilder.Entity<Car>().HasData(cars);
        }
    }
}
