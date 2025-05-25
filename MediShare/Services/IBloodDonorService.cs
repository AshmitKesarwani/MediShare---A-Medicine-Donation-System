using MediShare.Models;

namespace MediShare.Services
{
    public interface IBloodDonorService
    {
        public List<BloodDonor> GetAllBloodDonors();
        void AddBloodDonor(BloodDonor bloodDonor);
    }
}
