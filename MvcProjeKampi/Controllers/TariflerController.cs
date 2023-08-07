using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramewoek;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcProjeKampi.ViewModels;

namespace MvcProjeKampi.Controllers
{
    public class TariflerController : Controller
    {
        TariflerManager tariflerManager = new TariflerManager(new EfTariflerDal());
        YorumlarManager yorumlarManager = new YorumlarManager(new EfYorumlarDal());
        KullaniciManager kullanici = new KullaniciManager(new EfKullaniciDal());
        private readonly UserManager<AppUser> _userManager;

        public TariflerController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        TarifYorum tarifYorum = new TarifYorum();
        public IActionResult TarifDetay(int id)
        {
            tarifYorum.Deger1 = tariflerManager.TGetList().Where(x => x.Id == id).ToList();
            tarifYorum.Deger4 = (from p in yorumlarManager.TGetList()
                                 join e in _userManager.Users.ToList()
                                               on p.KullaniciId equals e.Id
                                 join t in tariflerManager.TGetList()
                                               on p.TarifId equals t.Id
                                 select new YorumlarTmp2
                                 {
                                     Id = p.Id,
                                     KullaniciAdi = e.Ad + " " + e.Soyad,
                                     Yorum = p.Yorum,
                                     TarifId = t.Id
                                 }).Where(x => x.TarifId == id).ToList();

            return View(tarifYorum);
            
        }


        [HttpPost]
        public async Task<IActionResult> TarifDetay(int id, TarifeYorumViewModel tarifeYorumViewModel )
        {
            var userId = await _userManager.FindByNameAsync(User.Identity!.Name!);
            var tarifId = id;

            var yorumlar = new Yorumlar()
            {
                KullaniciId = userId.Id,
                TarifId = tarifId,
                Yorum = tarifeYorumViewModel.Yorum,
            };

            yorumlarManager.TAdd(yorumlar);
            return RedirectToAction("TarifDetay","Tarifler");

            
        }
    }
}
