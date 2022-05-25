using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalProject.Controllers
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

        public IActionResult Homepage()
        {
            return View();
        }

        public IActionResult Addddoctor()
        {
            return View();

        }
        public IActionResult Addpatient()
        {
            return View();
        }

        public IActionResult Appointment()
        {
            return View();
        }
        [Route("Index1")]
        public IActionResult Index1()
        {
            return View();
        }
        [Route("Homepage1")]
        public IActionResult Homepage1()
        {
            return View();
        }
        [Route("Added")]
        public IActionResult Added()
        {
            return View();
        }
        [Route("Added1")]
        public IActionResult Added1()
        {
            return View();
        }


        //public IActionResult Display()
        //{
        //    project Vobj = new project();
        //    List<Appointment> ScheduleList = new List<Appointment>();
        //    ScheduleList = Vobj.Displayapt();
        //    return View(ScheduleList);
        //}

        public IActionResult PatientAD(Addpatient AD)
        {
            project mobj = new project();
            int result = mobj.PatientAD(AD);
            if (result == 1)
                return RedirectToAction("Added");
            else
                return View("Addpatient");

           
        }
        public IActionResult ADDAPPOINTMENT(Appointment AD)
        {
            project mobj = new project();
            int result = mobj.ADDAPPOINTMENT(AD);
            if (result == 1)
                return RedirectToAction("Displayappointment",AD);
            else
                return View("Appointment");
        }
            public IActionResult DoctorAD(Adddoctor AD)
        {
            project mobj = new project();
            int result = mobj.DoctorAd(AD);
            if (result == 1)
                return RedirectToAction("Added");
            else
                return View(" Adddoctor");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Validate(user us)
        {
            if (ModelState.IsValid)
            {
                project pobj = new project();
                int result = pobj.CheckUse(us);
                if (result == 1)
                {
                    return View("Homepage");
                }
                else
                {
                    return View("Login");
                }

            }
            else
            {
                return View("Index");
            }
        }
        public IActionResult Displayappointment()
        {
            List<Appointment> listSchedules = new List<Appointment>();
            project dobj = new project();
            listSchedules = dobj.Displayapt();
            return View(listSchedules);
        }
        [Route("Displaydoctor")]
        public IActionResult Displaydoctor()
        {
            List<Adddoctor> listSchedules = new List<Adddoctor>();
            project dobj = new project();
            listSchedules = dobj.Displaydoc();
            return View(listSchedules);
        }
        public IActionResult Deleteda(int id)
            {
                project cobj = new project();
                int result = cobj.Deletedat(id);
                if (result == 1)
                    return View("Added1");
                else
            return View("Displayappointment");
        }

        }
    }


