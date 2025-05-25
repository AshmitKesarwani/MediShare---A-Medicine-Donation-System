using MediShare.Models;
using MediShare.ViewModels;
using Newtonsoft.Json;

namespace MediShare.Services
{
    public class ClaimerService : IClaimerService

    {
      
        public void ClaimMedicine(Claimer claimer)
        {
			try
			{
                using (HttpClient client = new HttpClient())
                {
                    //Set Rest Api Base Address
                    client.BaseAddress = new Uri("http://localhost:5288/");
                    //Converting model data to json data
                    var contentData = new StringContent(JsonConvert.SerializeObject(claimer), System.Text.Encoding.UTF8, "application/json");
                    //Call api router
                    HttpResponseMessage response = client.PutAsync("api/Claimer/ClaimMedicine", contentData).Result;
                }
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
