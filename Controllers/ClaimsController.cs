using Microsoft.AspNetCore.Mvc;
using ST10390916_PROG_POE.Models;

namespace ST10390916_PROG_POE.Controllers
{
    public class ClaimsController : Controller
    {
        [HttpGet]
        public IActionResult ReviewClaims()
        {
            Claim claim = new Claim();
            User user = new User();
            List<Claim> claims = claim.GetPendingClaims();
            ViewData["Claims"] = claims;
            ViewData["User"] = user;
            return View();
        }

        public IActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateClaimStatus(int claimID, ClaimStatus status)
        {
            Claim claim = new Claim();
            claim.UpdateClaim(claimID, status);
            return RedirectToAction("ReviewClaims", "Claims");
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            claim.UserID = HttpContext.Session.GetInt32("UserID").Value;
            claim.Status = ClaimStatus.Pending;
            claim.ClaimDate = DateOnly.FromDateTime(DateTime.Now);
            claim.SubmitClaim(claim);

            return RedirectToAction("YourClaims", "Claims");
        }

        [HttpGet]
        public IActionResult YourClaims()
        {
            Claim claim = new Claim();
            User user = new User();
            user = user.GetUser(HttpContext.Session.GetInt32("UserID").Value);
            List<Claim> claims = claim.GetClaimsByUserID(user.UserID);
            ViewData["Claims"] = claims;
            return View();
        }

    }
}
