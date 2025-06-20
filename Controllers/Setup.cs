
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WWWW.Controllers
{

    public class SetupController : Controller
    {
        public IActionResult Query()
        {
            return View();
        }
        public IActionResult Customization()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Ideas()
        {
            return View();
        }
        public IActionResult Planning()
        {
            return View();
        }
        
        [Authorize(Policy = "LateHoursPolicy")]
        public IActionResult Vendors()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        [Authorize(Policy = "ClientNavigationPolicy")]
        public IActionResult Portfolio()
        {
            return View();
        }
        public IActionResult ExploreEvents()
        {
            return View();
        }
        public IActionResult Standard()
        {
            return View();
        }
        public IActionResult Luxury()
        {
            return View();
        }
        [Authorize]
        [Authorize(Policy = "ClientNavigationPolicy")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
