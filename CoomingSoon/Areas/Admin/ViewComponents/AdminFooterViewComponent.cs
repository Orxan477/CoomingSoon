using Microsoft.AspNetCore.Mvc;

namespace CoomingSoon.Areas.Admin.ViewComponents
{
    public class AdminFooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
