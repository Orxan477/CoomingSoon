using CoomingSoon.Models;
using System.Collections.Generic;

namespace CoomingSoon.ViewModel
{
    public class HomeVM
    {
        public List<RightOption> RightOptions { get; set; }
        public Info Info { get; set; }
        public Subscribe Subscribe { get; set; }
        public Contact Contact { get; set; }
    }
}
