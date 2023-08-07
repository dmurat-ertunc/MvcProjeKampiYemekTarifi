using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramewoek;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HomePageController : Controller
    {


        TariflerManager tariflerManager = new TariflerManager(new EfTariflerDal());
        public IActionResult Index()
        {
            //var deger = tariflerManager.TGetList2();
            var g = tariflerManager.TGetList().Take(2).ToList();
            return View(g);
            
        }
        public PartialViewResult Part1()
        {
            return PartialView();
        }
    }
}
