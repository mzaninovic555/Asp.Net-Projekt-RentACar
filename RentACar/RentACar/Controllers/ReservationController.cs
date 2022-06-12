using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL;
using RentACar.Model;
using RentACar.Web.Models;

namespace RentACar.Web.Controllers
{
    [Authorize(Roles = "Admin,User")]
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

        [HttpPost]
        public async Task<IActionResult> IndexAjax(ReservationFilterModel filter)
        {
            AppUser user = await userManager.FindByIdAsync(userManager.GetUserId(base.User));
            var listRoles = await userManager.GetRolesAsync(user);


            IQueryable<Reservation> reservationQuery = 
                dbContext.Reservations
                    .Include(r => r.Car)
                    .Include(r => r.Store)
                    .Include(r => r.Store.City)
                    .Include(r => r.Store.City.Country)
                    .Include(r => r.Car.Brand)
                    .OrderBy(r => r.PickupDateTime);

            if (!listRoles.Contains("Admin"))
            {
                var userId = userManager.GetUserId(base.User);
                reservationQuery = reservationQuery.Where(r => r.UserID == userId).AsQueryable();
            }

            if (!string.IsNullOrWhiteSpace(filter.StoreCityName))
            {
                reservationQuery = reservationQuery
                .Where(r => r.Store.City.Name.ToLower().Contains(filter.StoreCityName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(filter.CarName))
            {
                reservationQuery = reservationQuery
                    .Where(r => (r.Car.Brand.Name + " " + r.Car.Model).ToLower().Contains(filter.CarName.ToLower()));
            }

            var model = reservationQuery.ToList();

            return PartialView("_IndexTable", model);
        }

        [ActionName("Create")]
        public IActionResult Create()
        {
            FillDropdownCarValues();
            FillDropdownStoreValues();

            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult Create(Reservation modelReservation)
        {
            var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
            if (ModelState.IsValid)
            {
                modelReservation.UserID = userManager.GetUserId(base.User);
                dbContext.Add(modelReservation);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                FillDropdownCarValues();
                FillDropdownStoreValues();
                return View();
            }
        }

        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var model = dbContext.Reservations.FirstOrDefault(r => r.ID == id);
            FillDropdownCarValues();
            FillDropdownStoreValues();

            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var reservation = dbContext.Reservations.Single(r => r.ID == id);
            var ok = await TryUpdateModelAsync(reservation);

            if (ok && ModelState.IsValid)
            {
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            FillDropdownCarValues();
            FillDropdownStoreValues();

            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAjax(int reservationID)
        {
            Reservation reservationToDelete = dbContext.Reservations
                .Where(r => r.ID == reservationID).FirstOrDefault();

            if (reservationToDelete == null)
            {
                return View();
            }

            dbContext.Reservations.Remove(reservationToDelete);
            dbContext.SaveChanges();

            return await IndexAjax(new ReservationFilterModel());
        }

        private void FillDropdownCarValues()
        {
            var selectItems = new List<SelectListItem>();

            //Polje je opcionalno
            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var car in this.dbContext.Cars.Include(c => c.Brand))
            {
                string carLabel = car.Brand.Name + " " + car.Model;
                listItem = new SelectListItem(carLabel, car.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.Cars = selectItems;
        }

        private void FillDropdownStoreValues()
        {
            var selectItems = new List<SelectListItem>();

            //Polje je opcionalno
            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var store in this.dbContext.Stores.Include(s => s.City))
            {
                string carLabel = store.Address + ", " + store.City.Name;
                listItem = new SelectListItem(carLabel, store.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.Stores = selectItems;
        }
    }
}
