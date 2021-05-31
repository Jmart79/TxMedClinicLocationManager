using System;
using System.Collections.Generic;
using System.Text;

namespace LocatioTracker.MobileApp.Models
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public string City { get; set; }

        public Clinic()
        {

        }

        public Clinic(int clinicId, string clinicName, string city)
        {
            ClinicId = clinicId;
            ClinicName = clinicName;
            City = city;

        }
    }
}
