using CoomingSoon.DAL;
using CoomingSoon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoomingSoon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController:Controller
    {
        private AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Contacts.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Contact dbContact = await _context.Contacts.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (dbContact == null) return NotFound();
            _context.Remove(dbContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
