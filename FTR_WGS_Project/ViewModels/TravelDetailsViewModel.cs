using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FTR_WGS_Project.Models;

namespace FTR_WGS_Project.ViewModels
{
    public class TravelDetailsViewModel
    {
        public Employee Employee { get; set; }

        public Country Country { get; set; }

        public City City { get; set; }

        public GCM GCM { get; set; }

        public Travel Travel { get; set; }

        public TravelDetail TravelDetail { get; set; }
    }
}