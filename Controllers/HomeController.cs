using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        private bool _isIndexToggled = false;

        public IActionResult Index()
        {
            // Toggle is OFF, return the original view
            var data = new List<ClientFeatures>
            {
                new ClientFeatures { ID = 1, Name = "Feature1", Abbreviation = "Description for Feature1" },
                new ClientFeatures { ID = 2, Name = "Feature2", Abbreviation = "Description for Feature2" },
                new ClientFeatures { ID = 3, Name = "Feature3", Abbreviation = "Description for Feature3" },
                new ClientFeatures { ID = 4, Name = "Feature4", Abbreviation = "Description for Feature4" }
            };

            if (_isIndexToggled)
            {
                // Toggle is ON, return a different view or data
                return View("DifferentView", data);
            }
            else
            {              
                return View(data); // Pass the data to the view
            }
        }

        public IActionResult ToggleIndex()
        {
            _isIndexToggled = !_isIndexToggled;
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        
        public IActionResult Login(string username, string password)
        {
            // Authenticate the user
            if (username == "admin" && password == "password")
            {
                var claims = new[] { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
