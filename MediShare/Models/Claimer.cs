using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediShare.Models
{
    public class Claimer
    {
        public string UserId { get; set; }

        [Required]
        public string MedicineId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Purpose { get; set; }

        [Required]
        public string ShippingAddress { get; set; }
    }
}
