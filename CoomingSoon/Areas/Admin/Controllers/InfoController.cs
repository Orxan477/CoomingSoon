using CoomingSoon.DAL;
using CoomingSoon.Models;
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
        public IActionResult UpdateInfo(int id)
        {
            Info info = _context.Info.Find(id);
            if (info == null) return NotFound();
            return View(info);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInfo(int id,Info info)
        {
            Info dbInfo = await _context.Info.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (dbInfo == null) return NotFound();
            bool isExistLeftHead = await _context.Info.AnyAsync(p => p.LeftHead.Trim()
                                                                    .ToLower() == info.LeftHead.Trim().ToLower());

            if (!isExistLeftHead)
            {
                dbInfo.LeftHead = info.LeftHead;
            }
            bool isExistLeftContent = await _context.Info.AnyAsync(p => p.LeftContent.Trim()
                                                                    .ToLower() == info.LeftContent.Trim().ToLower());

            if (!isExistLeftContent)
            {
                dbInfo.LeftContent = info.LeftContent;
            }

            bool isExistRightContent = await _context.Info.AnyAsync(p => p.RightContent.Trim()
                                                                   .ToLower() == info.RightContent.Trim().ToLower());

            if (!isExistRightContent)
            {
                dbInfo.RightContent = info.RightContent;
            }
            bool isExistRightDown = await _context.Info.AnyAsync(p => p.RightDownContent.Trim()
                                                                   .ToLower() == info.RightDownContent.Trim().ToLower());

            if (!isExistRightDown)
            {
                dbInfo.RightDownContent = info.RightDownContent;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateOption(int id)
        {
            RightOption rightOption = _context.RightOptions.Find(id);
            if (rightOption == null) return NotFound();
            return View(rightOption);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOption(int id, RightOption rightOption)
        {
            RightOption dbRightOption = await _context.RightOptions.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (dbRightOption == null) return NotFound();
            bool isExistOption = await _context.Info.AnyAsync(p => p.LeftHead.Trim()
                                                                    .ToLower() == rightOption.Option.Trim().ToLower());

            if (!isExistOption)
            {
                dbRightOption.Option = rightOption.Option;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
