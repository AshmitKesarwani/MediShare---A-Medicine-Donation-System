using MediShare.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MediShare.Services
{
    public class MedicineService : IMedicineService
    {
        public void AddMedicine(Medicine medicine)
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288/");
                //Converting model data to json data
                var contentData = new StringContent(JsonConvert.SerializeObject(medicine), System.Text.Encoding.UTF8, "application/json");
                //Call api router
                HttpResponseMessage response = client.PostAsync("api/Medicine/AddMedicine", contentData).Result;
            }
        }
        //SERVICE FOR GET ALL MEDICINE LIST OF MEDICINE
        public List<Medicine> GetAllMedicines()
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288/");
                //Set content type to application/Json
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("api/Medicine/GetAll").Result;
                List<Medicine> medicines= JsonConvert.DeserializeObject<List<Medicine>>(response.Content.ReadAsStringAsync().Result);
                return medicines;
            }
        }
        //FETCHING NAMES OF MEDICINES FROM CATEGORY TABLE BY CATEGORY ID

        public List<Medicine> GetMedicineByCategoryID(string Cid)
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288/");
                //Set content type to application/Json
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("api/Medicine/GetMedicineByCid/{Id}").Result;
                List<Medicine> medicines = JsonConvert.DeserializeObject<List<Medicine>>(response.Content.ReadAsStringAsync().Result);
                return medicines;
            }
        }
        //FETCHING LIST OF MEDICINE FROM MEDICINE TABLE BY MEDICINE ID

        public Medicine GetMedicineByid(string Id)
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288/");
                //Set content type to application/Json
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                //string route = $"api/User/Validate/string/string";
                HttpResponseMessage response = client.GetAsync($"api/Medicine/GetMedicineById/{Id}").Result;
                Medicine medicine = JsonConvert.DeserializeObject<Medicine>(response.Content.ReadAsStringAsync().Result);
                return medicine;
            }
        }
        //FETCHING LIST OF MEDICINE FROM MEDICINE TABLE BY MEDICINE NAME

        public Medicine GetMedicineByName(string medicineName)
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288/");
                //Set content type to application/Json
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                //string route = $"api/User/Validate/string/string";
                HttpResponseMessage response = client.GetAsync($"api/Medicine/GetMedicineByName/{medicineName}").Result;
                Medicine medicine = JsonConvert.DeserializeObject<Medicine>(response.Content.ReadAsStringAsync().Result);
                return medicine;
            }
        }
        //DELETING  MEDICINE FROM MEDICINE TABLE BY MEDICINE ID
        public void DeleteMedicine(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288/");
                //Call api router
                HttpResponseMessage response = client.DeleteAsync($"api/Medicine/DeleteMedicieById/{id}").Result;
            }
        }
        //UPDATING FIELDS OF MEDICINE IN MEDICINE TABLE
        public void Update(Medicine medicine)
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288/");
                var contentData = new StringContent(JsonConvert.SerializeObject(medicine), System.Text.Encoding.UTF8, "application/json");
                //Call api router
                HttpResponseMessage response = client.PutAsync("api/Medicine/UpdateMedicine", contentData).Result;
            }
        }
    }
}
