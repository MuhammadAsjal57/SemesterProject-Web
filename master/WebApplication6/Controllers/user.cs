using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Controllers
{
    public class user : Controller
    {
        public IActionResult Index()
        {
            if (TempData["userid"]==null)
            {
                return RedirectToAction("login","register");
            }
            else
            {
                return View();
            }
           
        }
        public ActionResult logout()
        {
            return RedirectToAction("login", "register");
        }

    }
}
