using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarTracker.Models
{
    public class Car
    {
        public int CarID { get; set; }
        public int CarMakeID { get; set; }
        public CarMake CarMake { get; set; }

        public string Description { get; set; }
    }
}