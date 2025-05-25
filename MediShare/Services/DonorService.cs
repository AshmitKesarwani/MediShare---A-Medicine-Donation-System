using MediShare.Models;
using MediShare.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MediShare.Services
{
    public class DonorService : IDonorService
    {
        //DONATE MEDICINE SERVICE
        public void DonateMedicine(DonorMedicineVM donorMedicine)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //Set Rest Api Base Address
                    client.BaseAddress = new Uri("http://localhost:5288/");
                    //Converting model data to json data
                    var contentData = new StringContent(JsonConvert.SerializeObject(donorMedicine), System.Text.Encoding.UTF8, "application/json");
                    //Call api router
                    HttpResponseMessage response = client.PutAsync("api/Donor/DonateMedicine", contentData).Result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //LIST OF DONORS SERVICE

        public List<Donor> GeAllDonors()
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288/");
                //Set content type to application/Json
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("api/Donor/GetAllDonors").Result;
                List<Donor> donors = JsonConvert.DeserializeObject<List<Donor>>(response.Content.ReadAsStringAsync().Result);
                return donors;
            }

        }
    }
}
