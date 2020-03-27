    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelTakip.Controllers.Resources;
using PersonelTakip.Models;
using PersonelTakip.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonelTakip.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles= "SistemYöneticisi")]
    public class YetkilendirmeController : Controller
{
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        readonly UserService userService;

        public YetkilendirmeController(UserManager<ApplicationUser> userManager,RoleManager<ApplicationRole> roleManager)
        {
            this.userService  = new UserService(userManager,roleManager);
            this.userManager = userManager;
            this.roleManager = roleManager;
        }




        [Route("")]
        [HttpGet]
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {

            var usersAndRoles = await userService.getUsersNameAndRoleNamesAsync();
            var model = usersAndRoles.Select(ur =>
              new YetkilendirmeListResource
              {
                  username = ur.Item1,
                  role = ur.Item2
              }
             );
            var roles = roleManager.Roles.ToList();
            ViewBag.roles = roles;
            return View(model);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> IndexPostAsync([FromBody ]YetkilendirmeListResource model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var role = await roleManager.FindByNameAsync(model.role);
           
            var user = await userManager.FindByNameAsync(model.username);
            if (role == null ||user==null)
                return BadRequest();
            await ClearAllUserRolesAsync(user);
            var result = await userManager.AddToRoleAsync(user,model.role);
            if(result.Succeeded) return Ok(Json("Başarılı"));

            return BadRequest();


        }



        private async Task ClearAllUserRolesAsync(ApplicationUser user)
        {
            var roles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, roles);
             }
    }
}
