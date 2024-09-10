using Microsoft.AspNetCore.Mvc;

namespace ST10390916_PROG_POE.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

    }
}
