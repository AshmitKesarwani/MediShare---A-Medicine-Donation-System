using MediShare.Models;

namespace MediShare.Services
{
    public interface IMedicineService
    {
        public void AddMedicine(Medicine medicine);
        public void DeleteMedicine(string id);
        List<Medicine> GetAllMedicines();
        Medicine GetMedicineByName(string medicineName);
        Medicine GetMedicineByid(string Id);
        List<Medicine> GetMedicineByCategoryID(string CategoryID);
        void Update(Medicine medicine);
    }
}
