using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcProjeKampi.ViewModels;
using System.Collections;
using System.Data;


namespace MvcProjeKampi.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IndexAsync( )
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var adminAnaSayfaViewModel = new AdminAnaSayfaViewModel()
            {
                Ad = currentUser.Ad,
                Soyad = currentUser.Soyad,
            };
            return View(adminAnaSayfaViewModel);
        }

        public IActionResult Grafik1()
        {
            //ArrayList list1 = new ArrayList();
            //ArrayList list2 = new ArrayList();
            ////var erkekKul = _userManager.Users.Select(x => x.Cinsiyet == "Erkek");
            ////var kadinKul = _userManager.Users.Select(x => x.Cinsiyet == "Kadın");
            //var degerler= _userManager.Users.ToList();

            //degerler.ToList().ForEach(x=> list1.Add(x.Cinsiyet == "Kadın"));
            //degerler.ToList().ForEach(y=> list2.Add(y.Cinsiyet == "Erkek"));

            //var graf = new Chart
            
            return View();
        }
    }
}
