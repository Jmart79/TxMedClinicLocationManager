using System;
using System.Collections.Generic;
using System.Text;

namespace LocatioTracker.MobileApp.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Role { get; set; }
        public string Location { get; set; } = null;
    }
}
