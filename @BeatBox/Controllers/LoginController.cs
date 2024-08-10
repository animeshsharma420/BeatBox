using Microsoft.AspNetCore.Mvc;

namespace _BeatBox.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginPage()
        {
            return View();
        }
    }
}
