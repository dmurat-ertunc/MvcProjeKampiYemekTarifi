using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampi.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
