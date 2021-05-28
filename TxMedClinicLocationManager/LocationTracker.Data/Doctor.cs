using System;
using System.Collections.Generic;
using System.Text;

namespace LocationTracker.Data
{
    public class Doctor : IPerson
    {
        public string Role { get;  set; }
        public Doctor()
        {
            Role = "doctor";
        }
    }
}
