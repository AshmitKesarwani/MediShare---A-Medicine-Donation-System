using MediShare.Models;
using MediShare.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;

namespace MediShare.Controllers
{
    public class ClaimerController : Controller
    {
        private readonly IClaimerService _claimerService;
        private readonly IMedicineService medicineService;
        private readonly ICategoryService categoryService;
        public ClaimerController()
        {
            _claimerService = new ClaimerService();
            medicineService = new MedicineService();
            categoryService = new CategoryService();    

        }
        public IActionResult GetAllCategory() //Fetching the list of category table
        {
            List<Category> category= categoryService.GetAllCategories();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in category)
            {
                items.Add(new SelectListItem() { Text=item.CategoryName,Value=item.CategoryId });
            }
            ViewBag.Items = items;
            return View(category);
        
        }
        [HttpGet]//Request type
        public IActionResult Claim()//For User to Claim Medicine
        {

            List<Medicine> list = medicineService.GetAllMedicines();//Fetching the list of medicines by GetALLMed method
            List<SelectListItem> items = new List<SelectListItem>();//Creating List of all the medicines
            foreach (var item in list)//Iterating in the Loop 
            {
                items.Add(new SelectListItem() { Text = item.MedicineName, Value = item.MedicineId });
            }
            ViewBag.Items = items;

            return View();
        }
        [HttpPost]
        public IActionResult Claim(Claimer claimer)
        {
            claimer.UserId = HttpContext.Session.GetString("UserId");//Using UserId From the Session
            _claimerService.ClaimMedicine(claimer);//Calling the method from Service Method
            return RedirectToAction("ShippedOrder");//Redirecting when action is performed or Claimer request is approved
        }
   
        //Shipping Confirmation
        public IActionResult ShippedOrder()//View for the shipping Confirmation
        {
            return View();
        }

    }
}
