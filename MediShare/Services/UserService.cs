using MediShare.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MediShare.Services
{
    public class UserService : IUserService
    {
        //GET LIST OF ALL THE USERS FOR ADMIN
        public List<User> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288/");
                //Set content type to application/Json
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("api/User/GetAllUsers").Result;
                List<User> users = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
                return users;
            }
        }

        //For adding new user
        public void Register(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288");
                //Converting model data to json data
                var contentData = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
                //Call api router
                HttpResponseMessage response = client.PostAsync("api/User/Register", contentData).Result;
            }
        }
        //FOR VALIDATING USER WHILE LOGIN 
        public User Validate(string email, string pwd)
        {
            using (HttpClient client = new HttpClient())
            {
                //Set Rest Api Base Address
                client.BaseAddress = new Uri("http://localhost:5288");
                //Set content type to application/Json
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                //string route = $"api/User/Validate/string/string";
                HttpResponseMessage response = client.PostAsync($"api/User/Validate/{email}/{pwd}", null).Result;
                User user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);
                return user;
            }
        }
    }
}
