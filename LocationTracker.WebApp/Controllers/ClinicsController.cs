using LocationTracker.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.WebApp.Controllers
{
    [Controller]
    [Route("/Clinics")]
    public class ClinicsController : Controller
    {
        public IActionResult GetClinics()
        {
            var clinicManager = new ClinicManager();
            clinicManager.Clinics = new List<Clinic>();
            
           
            return View("Clinics",model: clinicManager);
        }

        public IActionResult CreateClinic()
        {
            return View("NewClinic");
        }
        public IActionResult CreateClinic(Clinic newClinic)
        {
            //add clinic to Db
            return View("Clinics");
        }

        public IActionResult UpdateClinic()
        {
            return View("ClinicInfo");
        }

        public IActionResult UpdateClinic(Clinic updatedClinic)
        {
            //update clinic
            return View("Clinics");
        }
    }
}
