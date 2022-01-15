using CoomingSoon.DAL;
using System.Collections.Generic;
using System.Linq;

namespace CoomingSoon.Services
{
    public class LayoutServices
    {
        private AppDbContext _context;

        public LayoutServices(AppDbContext context)
        {
            _context = context;
        }
        public Dictionary<string,string> GetSetting()
        {
            return _context.Settings.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
