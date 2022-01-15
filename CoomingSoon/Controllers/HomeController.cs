using CoomingSoon.DAL;
using CoomingSoon.Models;
using CoomingSoon.Services;
using CoomingSoon.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoomingSoon.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        private LayoutServices _layoutServices;

        public HomeController(AppDbContext context, LayoutServices layoutServices )
        {
            _context = context;
            _layoutServices = layoutServices;
        }
        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> Settings = _layoutServices.GetSetting();
            TempData["Date"] = Settings["Time"];

            HomeVM homeVM = new HomeVM
            {
                Info = await _context.Info.FirstOrDefaultAsync(),
                RightOptions = await _context.RightOptions.ToListAsync(),
            };
            return View(homeVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(HomeVM homeVM)
        {
            if (!ModelState.IsValid) return View(homeVM);

            Contact contact = new Contact
            {
                Name=homeVM.Contact.Name,
                Email=homeVM.Contact.Email,
                Subject=homeVM.Contact.Subject,
                Message=homeVM.Contact.Message
            };
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe(HomeVM homeVM)
        {
            if (!ModelState.IsValid) return View(homeVM);

            Subscribe subscribe = new Subscribe
            {
                Email = homeVM.Subscribe.Email
            };
            await _context.Subscribes.AddAsync(subscribe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
