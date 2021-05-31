using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.WebApp.Controllers
{
    [Controller]
    [Route("Users")]
    public class UsersController : Controller
    {
        public IActionResult UpdateDoctorLocation([FromQuery] int doctorId, [FromQuery] string newLocation)
        {
            //make updateDoctorLocation(doctorId,newLocation) call
            return View("Clinics");
        }
    }
}
