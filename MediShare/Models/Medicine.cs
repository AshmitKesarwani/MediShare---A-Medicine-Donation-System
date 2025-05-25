using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediShare.Models
{
    public class Medicine
    {
        [Key]
        public string MedicineId { get; set; }

        [Required]
        public string MedicineName { get; set; }

        [Required]
        public string MedicineDescription { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public DateTime Expiry_Date { get; set; }
    }
}
