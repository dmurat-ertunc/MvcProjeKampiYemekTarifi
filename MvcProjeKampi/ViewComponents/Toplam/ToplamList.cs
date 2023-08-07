using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampi.ViewComponents.Toplam
{
    public class ToplamList : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public ToplamList(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Context c = new Context();
            ViewBag.v1 = _userManager.Users.Count();
            ViewBag.v2 = c.TblYorumlar.Count();
            ViewBag.v3 = c.TblTarifler.Count();
            ViewBag.v4 = c.TblContact.Count();
            return View();
        }
    }
}
