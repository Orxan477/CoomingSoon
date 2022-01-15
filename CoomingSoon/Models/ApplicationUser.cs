using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoomingSoon.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsActivated { get; set; }
    }
}
