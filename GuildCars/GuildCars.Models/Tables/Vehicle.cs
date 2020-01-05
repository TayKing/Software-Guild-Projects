using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int BodyStyleID { get; set; }
        public int TransmissionID { get; set; }
        public int ColorID { get; set; }
        public int InteriorID { get; set; }
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
