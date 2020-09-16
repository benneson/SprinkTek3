using Microsoft.AspNetCore.Mvc;
using SprintTek.Web.Controllers;

namespace SprintTek.Web.Public.Controllers
{
    public class AboutController : SprintTekControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}