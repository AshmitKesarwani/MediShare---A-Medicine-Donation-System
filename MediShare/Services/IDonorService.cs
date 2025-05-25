using MediShare.Models;
using MediShare.ViewModels;

namespace MediShare.Services
{
    public interface IDonorService
    {
        public void DonateMedicine(DonorMedicineVM donorMedicine);
        public List<Donor> GeAllDonors();
       
    }
}
