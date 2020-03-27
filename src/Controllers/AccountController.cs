using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using PersonelTakip.Controllers.Resources;
using PersonelTakip.Models;
using PersonelTakip.Models.AccountViewModels;
using PersonelTakip.Services;
using Serilog;

namespace PersonelTakip.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<ApplicationRole> roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            this.roleManager = roleManager;
        }

        [TempData]
        public string ErrorMessage { get; set; }


        [HttpPost]        
        [Authorize(Roles = "SistemYöneticisi")]
        public async Task<IActionResult> Delete([FromForm] string username)
        {
            if (username == "super.admin")
                return BadRequest();

            var user = await _userManager.FindByEmailAsync(username);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return Unauthorized();
            }

            await _userManager.DeleteAsync(user);

            return Redirect("/Yetkilendirme");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {   if(User.Identity.IsAuthenticated)
               return RedirectToAction(actionName:"Index",controllerName:"Home");
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Hatalı giriş denemesi.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

     

     
        [HttpGet]
        [Authorize(Roles= "SistemYöneticisi")]        
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            ViewBag.roles = roleManager.Roles.ToList();

            return View();
        }

        [HttpPost]
        [Authorize(Roles= "SistemYöneticisi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.username, Email = model.username };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var roleName = roleManager.Roles.FirstOrDefault(r=>r.Id==model.Role).Name;
                    await _userManager.AddToRoleAsync(user, roleName);
                 var logString = String.Format("{0} adlı kullanıcı {1} adlı yeni bir kullanıcı kaydetti.",User.Identity.Name,user.UserName);
                    Log.Information(logString);

                    return RedirectToAction(actionName:"Index",controllerName:"Yetkilendirme");
                }
                AddErrors(result);
           

             
               }
            ViewBag.roles = roleManager.Roles.ToList();

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        [Route("{username}")]
        [Authorize(Roles = "SistemYöneticisi")]
        public IActionResult ResetPassword(string username)
        {

            var model = new ResetPasswordViewModel { Username=username};
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SistemYöneticisi")]
        [Route("{username}")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }



            var user = await _userManager.FindByEmailAsync(model.Username);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return Unauthorized();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var logMss = String.Format("{0} adlı kullanıcı {1} adlı kullanıcının şifresini değiştirdi",User.Identity.Name,model.Username);
            Log.Information(logMss);
            var result = await _userManager.ResetPasswordAsync(user, token, model.Password);
            if (result.Succeeded)
            {

                return RedirectToAction("Index",controllerName:"Home");
            }
            AddErrors(result);
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> KullaniciSifreDegistir()
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return BadRequest();
            var model = new SifreDegistirResource();
            return View(model);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> KullaniciSifreDegistir(SifreDegistirResource model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user =await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return BadRequest();
            var result = await _userManager.ChangePasswordAsync(user,model.guncelSifre,model.yeniSifre);
            if (result.Succeeded)
            {
                return RedirectToAction("Index",controllerName:"Home");
            }
            AddErrors(result);
            return View(model);           
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}
