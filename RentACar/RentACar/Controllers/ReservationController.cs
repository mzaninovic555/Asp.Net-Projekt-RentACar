using Microsoft.AspNetCore.Mvc;
using RentACar.DAL;
using RentACar.Model;

namespace RentACar.Web.Controllers
{
    public class ReservationController : Controller
    {

        private RentACarDbContext dbContext;

        public ReservationController(RentACarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index()
        {


            return View();
        }
    }
}
