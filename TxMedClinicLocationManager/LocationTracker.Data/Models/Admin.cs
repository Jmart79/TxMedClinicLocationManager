using System;
using System.Collections.Generic;
using System.Text;

namespace LocationTracker.Data.Models
{
    public class Admin : IPerson
    {
        public string Role { get;  set; }
        public Admin()
        {
            Role = "admin";
        }
    }
}
