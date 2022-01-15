using CoomingSoon.DAL;
using CoomingSoon.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoomingSoon.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context )
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Info = await _context.Info.FirstOrDefaultAsync(),
                RightOptions = await _context.RightOptions.ToListAsync(),
            };
            return View(homeVM);
        }
    }
}
