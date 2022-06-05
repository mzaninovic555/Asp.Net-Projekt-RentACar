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

        public IActionResult Index()
        {
            IQueryable<Car> cars = dbContext.Cars.Include(c => c.Brand).AsQueryable();

            return View("Index", cars.ToList());
        }
    }
}
