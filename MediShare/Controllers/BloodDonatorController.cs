using MediShare.Models;
using MediShare.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediShare.Controllers
{
    public class BloodDonatorController : Controller
    {
		private readonly IBloodDonorService _bloodDonorService;

		//Initialising Service
		public BloodDonatorController()
		{
			_bloodDonorService = new BloodDonorService();
		}
		public IActionResult AddBloodDonor()  //To add Blood Donors in the table (Get )
		{
			return View();
		}
		[HttpPost] // Request type
        public IActionResult AddBloodDonor(BloodDonor bloodDonor)//Add DETAILS OF THE DONOR TO THE DATABASE
        {
			try
			{
				_bloodDonorService.AddBloodDonor(bloodDonor);
				return View(bloodDonor);

			}
			catch (Exception)
			{

				throw;
			}
        }
		//get all blood donors
		public IActionResult GetAllBloodDonor()
		{
			List<BloodDonor> bloodDonors = _bloodDonorService.GetAllBloodDonors();
			return View(bloodDonors);
		}
    }
}
