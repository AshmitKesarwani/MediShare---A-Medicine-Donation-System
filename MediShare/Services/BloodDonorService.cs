using MediShare.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MediShare.Services
{
    public class BloodDonorService : IBloodDonorService
    {
        //ADDING BLOOD DONOR DETAILS TO THE DATABASE
        public void AddBloodDonor(BloodDonor bloodDonor)
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288/");
                //Converting model data to json data
                var contentData = new StringContent(JsonConvert.SerializeObject(bloodDonor), System.Text.Encoding.UTF8, "application/json");
                //Call api router
                HttpResponseMessage response = client.PostAsync("api/BloodDonator/AddBloodDonor", contentData).Result;
            }
        }
        //LIST OF ALL BLOOD DONORS
        public List<BloodDonor> GetAllBloodDonors()
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288/");
                //Set content type to application/Json
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("api/BloodDonator/GetALLBloodDonor").Result;
                List<BloodDonor> donors = JsonConvert.DeserializeObject<List<BloodDonor>>(response.Content.ReadAsStringAsync().Result);
                return donors;
            }
        }
    }
}
