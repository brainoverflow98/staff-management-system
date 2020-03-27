using System;
using Microsoft.AspNetCore.Identity;

namespace PersonelTakip.Models
{
    public class ApplicationUserRole:IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
