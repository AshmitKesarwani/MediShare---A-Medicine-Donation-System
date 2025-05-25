using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediShare.Models
{
    public class Category
    {
        public string CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
}
