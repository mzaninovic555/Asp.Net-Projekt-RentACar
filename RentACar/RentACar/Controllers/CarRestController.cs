using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL;
using RentACar.Model;

namespace RentACar.Web.Controllers
{
    [ApiController]
    [Route("api/auti")]
    public class CarRestController : Controller
    {

        private RentACarDbContext dbContext;

        public CarRestController(RentACarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<CarDTO> cars = dbContext.Cars
                .Include(c => c.Brand)
                .Select(c => CarToCarDTO(c))
                .ToList();

            return Ok(cars);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            CarDTO? car = dbContext.Cars
                .Include(c => c.Brand)
                .Where(c => c.ID == id)
                .Select(c => CarToCarDTO(c))
                .FirstOrDefault();

            return car != null ? Ok(car) : NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            this.dbContext.Add(car);
            this.dbContext.SaveChanges();

            return Get(car.ID);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] Car car)
        {
            Car carForUpdate = this.dbContext.Cars.First(c => c.ID == id);

            if(carForUpdate == null) 
            {
                return NotFound();
            }

            carForUpdate.Model = car.Model;
            carForUpdate.PictureURL = car.PictureURL;
            carForUpdate.SeatCount = car.SeatCount;
            carForUpdate.ProductionYear = car.ProductionYear;
            carForUpdate.IsManual = car.IsManual;
            carForUpdate.HasBluetooth = car.HasBluetooth;
            carForUpdate.HasParkingSensors = car.HasParkingSensors;
            carForUpdate.IsElectric = car.IsElectric;
            carForUpdate.HasGps = car.HasGps;
            carForUpdate.BrandID = car.BrandID;

            this.dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            Car carToDelete = this.dbContext.Cars.FirstOrDefault(c => c.ID == id);

            if(carToDelete == null)
            {
                return NotFound();
            }

            this.dbContext.Cars.Remove(carToDelete);
            this.dbContext.SaveChanges();

            return Ok();
        }


        public static CarDTO CarToCarDTO(Car c)
        {
            return new CarDTO()
            {
                ID = c.ID,
                Model = c.Model,
                SeatCount = c.SeatCount,
                ProductionYear = c.ProductionYear,
                IsManual = c.IsManual,
                HasBluetooth = c.HasBluetooth,
                HasParkingSensors = c.HasParkingSensors,
                IsElectric = c.IsElectric,
                HasGps = c.HasGps,
                Brand = new BrandDTO() { ID = c.Brand.Id, Name = c.Brand.Name }
            };
        }
    }

    public class BrandDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class CarDTO
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public int SeatCount { get; set; }
        public int ProductionYear { get; set; }
        public bool IsManual { get; set; }
        public bool HasBluetooth { get; set; }
        public bool HasParkingSensors { get; set; }
        public bool IsElectric { get; set; }
        public bool HasGps { get; set; }
        public BrandDTO Brand { get; set; }
    }
}
