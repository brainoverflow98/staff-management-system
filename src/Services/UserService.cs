using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonelTakip.Models;

namespace PersonelTakip.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<List<Tuple<string, string>>> getUsersNameAndRoleNamesAsync()
        {
            var users =await userManager.Users.Include(u => u.UserRoles)
                                .ThenInclude(ur =>ur.Role).ToListAsync();

            var usersAndTheirRoleNames = users.Select(u =>
            {
                var userName = u.UserName;
                var roleName = extractRoleNameFromRoleCollection(u.UserRoles);

                return new Tuple<string, string>(userName, roleName);
            }).ToList();
            return usersAndTheirRoleNames;
        }



        #region
        private string extractRoleNameFromRoleCollection(ICollection<ApplicationUserRole> roles)
        {
            var userRoles = roles.ToList();
            if (userRoles.Count<1)
                return "";
          

          return  userRoles[0].Role.Name;
        }

        #endregion
    }
}
