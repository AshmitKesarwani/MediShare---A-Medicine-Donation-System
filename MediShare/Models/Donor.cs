using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediShare.Models
{
    public class Donor
    {
        [Key]
        public Guid DonateId { get; set; }

        [Required]
        public string DonorId { get; set; }

        [Required]
        public string MedicineId { get; set; }

        [Required(ErrorMessage ="Select Medicine")]
        public string MedicineName { get; set; }

        [Required(ErrorMessage ="Enter Quantity")]
        public int Quantity { get; set; }
        

        [Required(ErrorMessage ="Enter Expiry Date")]
        public DateTime Expiry_Date { get; set; }

    }
}
