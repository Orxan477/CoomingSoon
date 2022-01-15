using Microsoft.AspNetCore.Mvc;

namespace CoomingSoon.Areas.Admin.ViewComponents
{
    public class SidebarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
