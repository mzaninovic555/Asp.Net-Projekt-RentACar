using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL;
using RentACar.Model;

namespace RentACar.Web.Controllers
{
    public class CarController : Controller
    {
        private RentACarDbContext dbContext;

        public CarController(RentACarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Route("auti/{carID?}")]
        public IActionResult Index(int? carID)
        {
            IQueryable<Car> cars = dbContext.Cars.Include(c => c.Brand).AsQueryable();

            if (carID.HasValue)
            {
                cars = cars.Where(c => c.ID == carID);
            }
       

            return View("Index", cars.ToList());
        }
    }
}
