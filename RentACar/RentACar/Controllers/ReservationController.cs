using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentACar.DAL;
using RentACar.Model;

namespace RentACar.Web.Controllers
{
    public class ReservationController : Controller
    {
        private RentACarDbContext dbContext;
        private UserManager<AppUser> userManager;

        public ReservationController(RentACarDbContext dbContext, UserManager<AppUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }


        public IActionResult Index()
        {


            return View();
        }
    }
}
