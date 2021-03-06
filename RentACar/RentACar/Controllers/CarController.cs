using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL;
using RentACar.Model;
using RentACar.Models;

namespace RentACar.Web.Controllers
{
    public class CarController : Controller
    {
        private RentACarDbContext dbContext;
        private UserManager<AppUser> userManager;

        public CarController(RentACarDbContext dbContext, UserManager<AppUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [Route("auti")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [ActionName("Create")]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            FillDropdownValues();
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Car modelCar)
        {
            var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
            if (ModelState.IsValid)
            {
                dbContext.Add(modelCar);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                FillDropdownValues();
                return View();
            }
        }

        [ActionName("CreateBrand")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        [ActionName("CreateBrand")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateBrand(Brand modelBrand)
        {
            var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
            if (ModelState.IsValid)
            {
                dbContext.Add(modelBrand);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                FillDropdownValues();
                return View();
            }
        }

        [ActionName(nameof(Edit))]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int carID)
        {
            var model = dbContext.Cars.FirstOrDefault(c => c.ID == carID);
            FillDropdownValues();
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Edit))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditPost(int id)
        {
            var car = dbContext.Cars.Single(c => c.ID == id);
            var ok = await TryUpdateModelAsync(car);

            if (ok && ModelState.IsValid)
            {
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            FillDropdownValues();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult IndexAjax(CarFilterModel filter)
        {
            var carQuery = dbContext.Cars.Include(p => p.Brand).AsQueryable();

            //Primjer iterativnog građenja upita - dodaje se "where clause" samo u slučaju da je parametar doista proslijeđen.
            //To rezultira optimalnijim stablom izraza koje se kvalitetnije potencijalno prevodi u SQL
            if (!string.IsNullOrWhiteSpace(filter.CarBrand))
                carQuery = carQuery.Where(c => c.Brand.Name.ToLower().Contains(filter.CarBrand.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.CarModel))
                carQuery = carQuery.Where(c => c.Model.ToLower().Contains(filter.CarModel.ToLower()));

            var model = carQuery.ToList();

            return PartialView("_IndexTable", model);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAjax(int carID)
        {
            Car carToDelete = dbContext.Cars.Where(c => c.ID == carID).FirstOrDefault();

            if(carToDelete == null)
            {
                return View();
            }

            dbContext.Cars.Remove(carToDelete);
            dbContext.SaveChanges();

            return IndexAjax(new CarFilterModel());
        }

        private void FillDropdownValues()
        {
            var selectItems = new List<SelectListItem>();

            //Polje je opcionalno
            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var brand in this.dbContext.Brands)
            {
                listItem = new SelectListItem(brand.Name, brand.Id.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.Brands = selectItems;
        }
    }
}
