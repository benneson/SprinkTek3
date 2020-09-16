using Microsoft.AspNetCore.Mvc;
using SprintTek.Web.Controllers;

namespace SprintTek.Web.Public.Controllers
{
    public class HomeController : SprintTekControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}