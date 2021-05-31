using System;
using System.Collections.Generic;
using System.Text;

namespace LocationTracker.Data.Models
{
    public class ClinicManager
    {
        public IEnumerable<Clinic> Clinics { get; set; }
        public Person User { get; set; }
    }
}
