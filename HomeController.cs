using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project2.Models;
using project2.DAL;

namespace project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("landingpage")]
        public IActionResult landingpage()
        {
            return View();
        }
        [Route("signup")]
        public IActionResult signup()
        {
            return View();
        }
        public IActionResult add()
        {
            return View();
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Mainpage")]
        public IActionResult Shirts()
        {
            return View();
        }
        [Route("Suits")]
        public IActionResult Suits()
        {
            return View();
        }
        [Route("Pants")]
        public IActionResult Pants()
        {
            return View();
        }
        public IActionResult Homepage()
        {
            return View();
        }


        public IActionResult Validate(Signup us)
        {
            if (ModelState.IsValid)
            {
                data pobj = new data();
                int result = pobj.CheckUse(us);
                if (result == 1)
                {
                    return View("Homepage");
                }
                else
                {
                    return View("Homepage");
                }

            }
            else
            {
                return View("Index");
            }
        }


        public IActionResult signupp(Signup AD)
        {
            data mobj = new data();
            int result = mobj.signupp(AD);
            if (result == 1)
                return RedirectToAction("add");
            else
                return View("signup");


        }

        [Route("Bill")]
        public IActionResult Bill(int id,string pname,int price,cart cart)
        {
            List<Product> listproducts = new List<Product>();

            data dobj = new data();

            //int result = dobj.cart(cart);
            //if (result == 1)
                //return View("Homepage");


           listproducts = dobj.Displayproduct(id);
            return View(listproducts);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
