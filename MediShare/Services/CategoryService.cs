using MediShare.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MediShare.Services
{
    public class CategoryService : ICategoryService
    {
        // GET ALL THE LIST OF CATEGORIES OF MEDICINE
        public List<Category> GetAllCategories()
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288/");
                //Set content type to application/Json
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("api/Category/GetAllCategory").Result;//USING END POINT FOR THE CONNECTION
                List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(response.Content.ReadAsStringAsync().Result);//CONVERING JSON TO MODEL DATA
                return categories;
            }
        }
    }
}
