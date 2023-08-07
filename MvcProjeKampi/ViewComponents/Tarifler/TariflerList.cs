using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramewoek;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampi.ViewComponents.Tarifler
{
    public class TariflerList : ViewComponent
    {
        TariflerManager tariflerManager=new TariflerManager(new EfTariflerDal());
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values =tariflerManager.TGetList();
            return View(values);
        }
    }
}
