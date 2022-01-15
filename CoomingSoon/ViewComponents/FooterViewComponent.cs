using Microsoft.AspNetCore.Mvc;

namespace CoomingSoon.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
