using System;
using System.Collections.Generic;
using System.Text;

namespace LocationTracker.Data.Models
{
    public class Doctor : IPerson
    {
        public string Role { get;  set; }
        public string Location { get; set; }
        public Doctor()
        {
            Role = "doctor";
        }
    }
}
