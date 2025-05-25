using MediShare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediShare.Controllers
{
    public class MediShareController : Controller
    {
        //Login Page for Existing Donor 
        public IActionResult Login()
        {
            return View();
        }
        //Registration Page for New Donor

        [HttpPost]
        public IActionResult Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                return Json(registration);
            }
            else
            {
                return View();
            }
        }



        public IActionResult ContactUs() { 
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
