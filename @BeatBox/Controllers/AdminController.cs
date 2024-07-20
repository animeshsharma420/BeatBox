using Microsoft.AspNetCore.Mvc;

namespace _BeatBox.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminPanel()
        {
            return View();
        }
        public IActionResult Verify()
        {
            return View("Category", "Categories");
        }
    }
}
