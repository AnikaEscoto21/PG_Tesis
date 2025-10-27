using Microsoft.AspNetCore.Mvc;

namespace EvalySI_App.Controllers
{
    public class LandingPageController : Controller  
    {
        public IActionResult Index()
        {
            return View();  
        }

        public IActionResult Servicio()
        {
            return View();
        }

        public IActionResult Ubicacion()
        {
            return View();
        }

    }
}
