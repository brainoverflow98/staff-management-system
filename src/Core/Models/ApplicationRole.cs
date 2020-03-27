using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PersonelTakip.Models
{
    public class ApplicationRole:IdentityRole
    {
    public ICollection<ApplicationUserRole> UserRoles { get; set; }
    public ApplicationRole(){
        
    }
    
    public ApplicationRole(string roleName):base(roleName)
    {
    }       

    }
}
