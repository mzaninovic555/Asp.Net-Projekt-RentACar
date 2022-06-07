using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL;
using RentACar.Model;

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

        [ActionName("Create")]
        public IActionResult Create()
        {
            FillDropdownValues();
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
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

        [ActionName(nameof(Edit))]
        public IActionResult Edit(int carID)
        {
            var model = dbContext.Cars.FirstOrDefault(c => c.ID == carID);
            FillDropdownValues();
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Edit))]
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
