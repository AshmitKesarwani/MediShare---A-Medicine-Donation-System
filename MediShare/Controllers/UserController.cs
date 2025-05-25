using MediShare.Models;
using MediShare.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediShare.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }
        [HttpGet] //Request Type
        public IActionResult Create()//For REGISTERING NEW USER
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid) 
            {
                user.UserId = "U" + new Random().Next(1000);//GENERATING USERID WITH BUSINESS LOGIC
                _userService.Register(user);
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Logout() { 
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Login()//EXISTING USER TO LOGIN
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.Validate(login.Username , login.Password);//VALIDATING USERNAME AND PASSWORD
                if (user == null)
                {
                    ViewBag.ErrorMsg = "Invalid Credentails";//CREATING VIEWBAG WHEN THE VALIDATION IS UNSUCCESSFUL
                    return View();
                }
                else
                {
                    //Set Values in session
                    HttpContext.Session.SetString("UserId", user.UserId); //Storing UserId in Session                                                
                    // HttpContext.Session.SetString("Role", user.Role);
                    string role = user.Role;
                    if (role == "Admin")//VALIDATING THE ROLE OF ADMIN
                        return RedirectToAction("AdminDashboard");
                    else if (role == "User")
                        return RedirectToAction("UserDashboard");
                    else
                        return View();
                }
            }
            else
            {
                return View();
            }

        }
        //ADMIN DASHBOARD
        public IActionResult AdminDashboard(Medicine med)
        {
            var mod = new Medicine();
            return View(mod);
        }
        //USER DASHBOARD
        public IActionResult UserDashboard()
        {
            return View();
        }
        public IActionResult Index()
        {
            List<User> users = _userService.GetAll();
            return View(users);
        }
    }
}
