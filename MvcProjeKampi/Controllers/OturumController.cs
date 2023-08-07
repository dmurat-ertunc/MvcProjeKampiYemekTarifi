using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramewoek;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using MvcProjeKampi.ViewModels;
using System.Reflection.Metadata.Ecma335;
using ValidationResult = FluentValidation.Results.ValidationResult;
namespace MvcProjeKampi.Controllers
{
    public class OturumController : Controller
    {
        

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public OturumController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UyeOl()
        {
            return View();
        }
        //KullaniciManager kullaniciManager=new KullaniciManager(new EfKullaniciDal());
        [HttpPost]
        public async Task<IActionResult> UyeOl(UserSingUpViewModel userSingUpView)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser()
            {
                Ad = userSingUpView.Ad,
                Soyad = userSingUpView.Soyad,
                Cinsiyet = userSingUpView.Cinsiyet,
                PhoneNumber = userSingUpView.PhoneNumber,
                Email = userSingUpView.Email,
                UserName = userSingUpView.UserName,
                Age = userSingUpView.Age
            };
            var result = await _userManager.CreateAsync(appUser, userSingUpView.Password);
            if (result.Succeeded)
            {
                ViewBag.ms = "Kayıt olma işlemi başarıyla gerçekleşti";
            }
            foreach (IdentityError item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }
            return View();
        }
        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(LoginViewModel loginViewModel,string? returnUrl=null)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            returnUrl = returnUrl ?? Url.Action("Index", "HomePage");

            var hasUser = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if(hasUser == null)
            {
                ViewBag.msj = "E-Posta veya Şifre Yanlış.";
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(hasUser, loginViewModel.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(returnUrl!);
            }
            ViewBag.msj = "E-Posta veya Şifre Yanlış.";
            return View();
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        [Authorize]
        public async Task<IActionResult> Profil()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var userViewModel = new UserViewModel()
            {
                Id = currentUser.Id,
                Ad = currentUser.Ad,
                Soyad = currentUser.Soyad,
                Cinsiyet = currentUser.Cinsiyet,
                Age = currentUser.Age,
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                PasswordHash = currentUser.PasswordHash
            };
            return View(userViewModel);

        }

        [Authorize]
        public IActionResult PasswordChange()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var hasUser = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var checkOldPass=await _userManager.CheckPasswordAsync(hasUser, model.OldPassword);

            if(!checkOldPass)
            {
                ViewBag.err = "Eski Şifreniz Yanlış";
                return View();
            }
            if(model.OldPassword == model.NewPassword)
            {
                ViewBag.err = "Eski Şifreniz ile Yeni Şifre Aynı Olamaz";
                return View();
            }
            var resultChangePass= await _userManager.ChangePasswordAsync(hasUser,model.OldPassword,model.NewPassword);

            ViewBag.ok = "Şifre Güncellendi";

            return View();
        }

        [Authorize]
        public async Task<IActionResult> EditUser()
        {
            var hasUser = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var userEditViewModel = new UserEditViewModel()
            {
                Id = hasUser.Id,
                Ad = hasUser.Ad,
                Soyad = hasUser.Soyad,
                Age = hasUser.Age,
                Cinsiyet = hasUser.Cinsiyet,
                UserName = hasUser.UserName,
                Email = hasUser.Email,
            };
            return View(userEditViewModel);

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditUser(UserEditViewModel userEditViewModel)
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name!);

            currentUser.Ad= userEditViewModel.Ad;
            currentUser.Soyad= userEditViewModel.Soyad;
            currentUser.Age= userEditViewModel.Age;
            currentUser.Cinsiyet= userEditViewModel.Cinsiyet;
            currentUser.UserName= userEditViewModel.UserName;
            currentUser.Email= userEditViewModel.Email;

            var updateUser= await _userManager.UpdateAsync(currentUser);
            if(updateUser.Succeeded)
            {
                ViewBag.ok = "Güncelleme İşlemi Başarılı";
            }
            return View();
        }
    }
}
