using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonelTakip.Models;

namespace PersonelTakip.Controllers
{   [Authorize]
    public class HomeController : Controller
    {
        [Route("")]
        [Authorize]
        public IActionResult Index()
        {
            return Redirect("/Personel/Liste");            
        }


      

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
