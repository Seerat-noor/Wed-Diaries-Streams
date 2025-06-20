using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WWW.Controllers
{
    [Authorize] // Ensures only logged-in users can access chat
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Username = User.Identity.Name;
            return View();
        }
    }
}
