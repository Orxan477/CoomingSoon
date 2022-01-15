using CoomingSoon.DAL;
using CoomingSoon.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoomingSoon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InfoController : Controller
    {
        private AppDbContext _context;

        public InfoController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Info=await _context.Info.FirstOrDefaultAsync(),
                RightOptions= await _context.RightOptions.ToListAsync(),
            };
            return View(homeVM);
        }
    }
}
