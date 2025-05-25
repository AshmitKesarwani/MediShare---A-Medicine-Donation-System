using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediShare.Models
{
    public class BloodDonor
    {
       
        public string DonorName { get; set; }
        
        public string Age { get; set; }
       
        public string Gender { get; set; }
      
        public string BloodGroup { get; set; }
        public string LastDonatedDate { get; set; }
        public string ContactNo { get; set; }
        
        public string Address { get; set; }  
        public string City { get; set; } 
        public string PinCode { get; set; }
        public string MedicalHistory { get; set; }

    }
}
