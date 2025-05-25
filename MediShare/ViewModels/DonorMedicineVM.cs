namespace MediShare.ViewModels
{
    public class DonorMedicineVM
    {
        public Guid DonateId { get; set; }
        public string DonorId { get; set; }
        public string MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public DateTime Expiry_Date { get; set; }
    }
}
