using Microsoft.AspNetCore.Mvc;

namespace CoomingSoon.Areas.Admin.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
