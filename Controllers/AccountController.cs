
using Microsoft.AspNetCore.Mvc;

namespace WWW.Controllers
{
    public class AccountController : Controller
    {

        //to call signup razor pg
        public IActionResult Register()
        {
            return View();
        }
        //to call logn up razor pg
        public IActionResult Login()
        {
            return View();
        }

    }
}
