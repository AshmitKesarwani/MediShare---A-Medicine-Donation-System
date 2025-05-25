using MediShare.Models;

namespace MediShare.Services
{
    public interface IClaimerService
    {
        void ClaimMedicine(Claimer claimer);
    }
}
