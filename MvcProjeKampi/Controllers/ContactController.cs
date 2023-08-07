using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramewoek;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcProjeKampi.ViewModels;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        private readonly UserManager<AppUser> _userManager;
        public ContactController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(MesajViewModel mesajViewModel)
        {
            //if(!ModelState.IsValid)
            //{
            //    return View();
            //}
            var ff = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var contact = new Contact()
            {
                kullaniciId = ff.Id,
                Mesaj = mesajViewModel.Mesaj,
                Konu = mesajViewModel.Konu,
            };
            contactManager.TAdd(contact);
            return View();

            //return RedirectToAction("Index","Contact");
        }
    }
}
