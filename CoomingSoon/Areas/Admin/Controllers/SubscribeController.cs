using CoomingSoon.DAL;
using CoomingSoon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoomingSoon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscribeController : Controller
    {
        private AppDbContext _context;

        public SubscribeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Subscribes.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Subscribe dbsubscribe = await _context.Subscribes.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (dbsubscribe == null) return NotFound();
            _context.Remove(dbsubscribe);
           await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
