using MediShare.Models;
using MediShare.Services;
using MediShare.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace MediShare.Controllers
{
    public class DonorController : Controller
    {
        private readonly IDonorService _donorService;
        private readonly IMedicineService _medicineService;

        public DonorController() { 
            _donorService = new DonorService();
            _medicineService = new MedicineService();
        }
        //For User to Donate Medicine
        public IActionResult DonateMedicine()
        {
            List<Medicine> list = _medicineService.GetAllMedicines();//List of all the medicine
            List<SelectListItem> items = new List<SelectListItem>();//Adding medicines  to a list
            foreach (var item in list)
            {
                items.Add(new SelectListItem() { Text = item.MedicineName, Value = item.MedicineId });//Fetching medicine name with medicine id

            }
            ViewBag.Items= items;//Creating Viewbag for the list items
            return View();
        }
        [HttpPost]
        public IActionResult DonateMedicine(DonorMedicineVM donorMedicine)//Using ViewModel To Aggregate Two models 
        {
           string donorId = HttpContext.Session.GetString("UserId");//Using UserId from Session
            donorMedicine.DonorId = donorId;
            donorMedicine.DonateId=Guid.NewGuid();
            string medecineId = donorMedicine.MedicineId;
            Medicine medicine = _medicineService.GetMedicineByid(medecineId);
            donorMedicine.MedicineName = medicine.MedicineName;
            _donorService.DonateMedicine(donorMedicine);
            return RedirectToAction("PickUp");
        }
        public IActionResult PickUp() //Redirecting to pickup when donation request is approved
        {
            return View();
        }
        public IActionResult GetAllDonor()//List of all Donors (For Admin)
        {
            List<Donor> donors = _donorService.GeAllDonors();
            return View(donors);
        }
    }
}
