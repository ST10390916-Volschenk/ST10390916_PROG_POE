using Microsoft.AspNetCore.Mvc;
using ST10390916_PROG_POE.Models;

namespace ST10390916_PROG_POE.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Login()
        {
            HttpContext.Session.SetInt32("UserID", -1);
            HttpContext.Session.SetString("UserRole", "Lecturer");

            return View();
        }

        public IActionResult SignUp()
        {
            HttpContext.Session.SetInt32("UserID", -1);
            HttpContext.Session.SetString("UserRole", "Lecturer");
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            User user = new User();
            int userID = user.CheckUser(email, password);
            if ((userID != -1) && (userID != null))
            {
                user = user.GetUser(userID);
                HttpContext.Session.SetInt32("UserID", userID);
                HttpContext.Session.SetString("UserRole", user.UserRole.ToString());
                TempData["LoginFailed"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginFailed"] = "Email or password is incorrect.";
                return View();
            }            
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            string msg = user.AddNewUser(user);
            if (msg == "")
            {
                int userID = user.UserID;
                HttpContext.Session.SetInt32("UserID", userID);
                HttpContext.Session.SetString("UserRole", user.UserRole.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["SignUpFailed"] = msg;
                return RedirectToAction("Login", "User");
            }
            

        }

    }
}
