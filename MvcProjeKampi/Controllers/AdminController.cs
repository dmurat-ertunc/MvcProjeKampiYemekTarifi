using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramewoek;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
//using FluentValidation;
//using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MvcProjeKampi.ViewModels;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MvcProjeKampi.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _sigInManager;

        public AdminController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _sigInManager= signInManager;
            _userManager = userManager;
        }
        
        KullaniciManager kullaniciManager = new KullaniciManager(new EfKullaniciDal());

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        TariflerManager tariflerManager = new TariflerManager(new EfTariflerDal());

        [Authorize(Roles = "Admin")]
        public IActionResult Tariflist()
        {
            var values = tariflerManager.TGetList();
            return View(values);
        }
        KategorilerManager kategorilerManager = new KategorilerManager(new EfKategorilerDal());
        [Authorize(Roles = "Admin")]
        public IActionResult AddTarif()
        {
            var vars = kategorilerManager.TGetList();
            return View(vars);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddTarif(AddTarifViewModel tarifler)
        {
            var vars = new Tarifler()
            {
                TarifAd = tarifler.TarifAd,
                Aciklama = tarifler.Aciklama,
                Tarif = tarifler.Tarif,
                Foto = tarifler.Foto,
                KategoriId = tarifler.KategoriId,
            };
            tariflerManager.TAdd(vars);
            return RedirectToAction("TarifList");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteTarif(int id)
        {
            var silinecekTarif= tariflerManager.TGetById(id);
            tariflerManager.TDelete(silinecekTarif);
            return RedirectToAction("TarifList","Admin");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditTarif(int id)
        {

            var editDeger = tariflerManager.TGetById(id);
            //var editTarifViewModel = new EditTarifViewModel()
            //{
            //    TarifAd = editDeger.TarifAd,
            //    Aciklama = editDeger.Aciklama,
            //    Tarif = editDeger.Tarif,
            //    Foto = editDeger.Foto,
            //};
            return View(editDeger);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditTarif(Tarifler tarifler)
        {

            tariflerManager.TUpdate(tarifler);
            return RedirectToAction("TarifList", "Admin");
        }



        YorumlarManager yorumlarManager = new YorumlarManager(new EfYorumlarDal());

        [Authorize(Roles = "Admin")]
        public IActionResult Yorumlar()
        {
            var person = (from p in yorumlarManager.TGetList()
            join e in _userManager.Users.ToList() 
                          on p.KullaniciId equals e.Id
            join t in tariflerManager.TGetList()
                          on p.TarifId equals t.Id
                          select new YorumlarTmp
                          {
                              Id = p.Id,
                              KullaniciAdi = e.Ad+" "+e.Soyad,
                              Yorum = p.Yorum,
                              TarifId = t.TarifAd
                          }).ToList();
            return View(person);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult YorumDelete(int id)
        {
            var silinecekTarif = yorumlarManager.TGetById(id);
            yorumlarManager.TDelete(silinecekTarif);
            return RedirectToAction("Yorumlar", "Admin");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Kullanici()
        {
            var t = _userManager.Users.ToList();
            return View(t);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AddKullanici()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddKullanici(UserAddViewModel userAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser()
            {
                Ad = userAddViewModel.Ad,
                Soyad = userAddViewModel.Soyad,
                Cinsiyet = userAddViewModel.Cinsiyet,
                PhoneNumber = userAddViewModel.PhoneNumber,
                Email = userAddViewModel.Email,
                UserName = userAddViewModel.UserName,
                Age = userAddViewModel.Age
            };
            var result = await _userManager.CreateAsync(appUser, userAddViewModel.Password);
            if (result.Succeeded)
            {
                ViewBag.ms = "Kullanıcı ekleme işlemi başarıyla gerçekleşti";
            }
            foreach (IdentityError item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteKullanici(string id)
        {
            var idBul = await _userManager.FindByIdAsync(id);
            var kullaniciSil = await _userManager.DeleteAsync(idBul);

            return RedirectToAction("Kullanici","Admin");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditKullanici(string id)
        {
            var hasUser = await _userManager.FindByIdAsync(id);

            var userUpdateToAdminViewModel = new UserUpdateToAdminViewModel()
            {
                //Id = hasUser.Id,
                Ad = hasUser.Ad,
                Soyad = hasUser.Soyad,
                Age = hasUser.Age,
                PhoneNumber = hasUser.PhoneNumber,
                Cinsiyet = hasUser.Cinsiyet,
                UserName = hasUser.UserName,
                Email = hasUser.Email,
            };
            return View(userUpdateToAdminViewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditKullanici(UserUpdateToAdminViewModel userUpdateToAdminViewModel)
        {
            var currentUser = await _userManager.FindByIdAsync(userUpdateToAdminViewModel.Id);

            currentUser.Ad = userUpdateToAdminViewModel.Ad;
            currentUser.Soyad = userUpdateToAdminViewModel.Soyad;
            currentUser.Age = userUpdateToAdminViewModel.Age;
            currentUser.PhoneNumber = userUpdateToAdminViewModel.PhoneNumber;
            currentUser.Cinsiyet = userUpdateToAdminViewModel.Cinsiyet;
            currentUser.UserName = userUpdateToAdminViewModel.UserName;
            currentUser.Email = userUpdateToAdminViewModel.Email;

            var updateUser = await _userManager.UpdateAsync(currentUser);
            if (updateUser.Succeeded)
            {
                ViewBag.ok = "Güncelleme İşlemi Başarılı";
            }
            return View();

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminInfo()
        {
            var adm = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var adminInfoViewModel = new AdminInfoViewModel()
            {
                Id=adm.Id,
                Ad = adm.Ad,
                Soyad = adm.Soyad,
                Cinsiyet = adm.Cinsiyet,
                Age = adm.Age,
                Email = adm.Email,
                UserName = adm.UserName,
                PasswordHash = adm.PasswordHash


            };
            return View(adminInfoViewModel);
        }


        ContactManager contactManager = new ContactManager(new EfContactDal());

        [Authorize(Roles = "Admin")]
        public IActionResult ContactList()
        {
            var contact = (from p in contactManager.TGetList()
                          join e in _userManager.Users.ToList()
                                        on p.kullaniciId equals e.Id
                          select new YorumlarTmp3
                          {
                              Id = p.Id,
                              KullaniciAdi = e.Ad + " " + e.Soyad,
                              Konu = p.Konu,
                              Mesaj = p.Mesaj
                          }).ToList();
            return View(contact);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminLogin(LoginViewModel loginViewModel, string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "HomePage");

            var hasUser = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (hasUser == null)
            {
                ViewBag.msj = "E-Posta veya Şifre Yanlış.";
                return View();
            }
            var result = await _sigInManager.PasswordSignInAsync(hasUser, loginViewModel.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(returnUrl!);
            }
            ViewBag.msj = "E-Posta veya Şifre Yanlış.";
            return View();
        }
    }

    
}
