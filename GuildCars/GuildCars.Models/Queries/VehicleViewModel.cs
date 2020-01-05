using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleViewModel
    {
        public int VehicleID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string BodyStyle { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public int VehicleYear { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public int MSRP { get; set; }
        public int Price { get; set; }
        public string VehicleDescription { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSold { get; set; }
    }
}
