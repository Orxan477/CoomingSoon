using CoomingSoon.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoomingSoon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingController : Controller
    {
        private AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Settings.FirstOrDefault());
        }
    }
}
