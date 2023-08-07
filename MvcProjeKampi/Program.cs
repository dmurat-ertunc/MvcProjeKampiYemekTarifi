using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MvcProjeKampi.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true; // epostalar unique olsun 
    options.Password.RequiredLength = 6; // þifre en az 6 karakter olsun
    options.Password.RequireNonAlphanumeric = false; //saçma sapan karakterler zorunlu deðil
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

}).AddErrorDescriber<LocalizationErrorDescriber>().AddEntityFrameworkStores<Context>();

builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder = new CookieBuilder();

    cookieBuilder.Name = "Kokiyim";
    opt.LoginPath = new PathString("/Oturum/GirisYap"); //giriþ engellendiði sayfayý açmaya çalýþtýgýmýz zaman bizi yönlerdieceði sayfa
    opt.LogoutPath = new PathString("/Oturum/LogOut"); // çýkýþ yapýlan fonksiyon
    opt.Cookie = cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(10);
    opt.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
   );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomePage}/{action=Index}/{id?}");

app.Run();
