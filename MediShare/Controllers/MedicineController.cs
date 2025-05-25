using MediShare.Controllers;
using MediShare.Models;
using MediShare.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace MediShare.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IMedicineService _medicineService;

        public MedicineController()
        { 
            _medicineService = new MedicineService();//INITIALIZING SERVICE METHOD
        }
        //Geta All Medicine List(For Admin)
        public IActionResult GetAllMedicine()
        {
            List<Medicine> medicines = _medicineService.GetAllMedicines();
            return View(medicines);
        }
        //Add New Medicine in the DATABASE (FOR ADMIN)

        [HttpGet]
        public IActionResult AddMedicine()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMedicine(Medicine medicine) 
        {
            HttpContext.Session.SetString("MedicineId", medicine.MedicineId);
            _medicineService.AddMedicine(medicine);
            return RedirectToAction("GetAllMedicine");

        }
        
        public IActionResult DeleteMedicine(string MedicineId)
        {
            _medicineService.DeleteMedicine(MedicineId);
                return RedirectToAction("GetAllMedicine");
        }
        public IActionResult Edit(string MedicineId)
        {
            Medicine medicine = _medicineService.GetMedicineByid(MedicineId);   
            return View(medicine);
        }
        [HttpPost] 
        public IActionResult Edit(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                _medicineService.Update(medicine);
                return RedirectToAction("GetAllMedicine");
            }
            else
            {
                return View();
            }
        }
    }
}
