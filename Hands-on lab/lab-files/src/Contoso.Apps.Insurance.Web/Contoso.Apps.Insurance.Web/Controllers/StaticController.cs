using Microsoft.AspNetCore.Mvc;

namespace Contoso.Apps.Insurance.Web.Controllers
{
    public class StaticController : Controller
    {
        public StaticController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}