using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Sales
    {
        public int SaleID { get; set; }
        public string UserID { get; set; }
        public int VehicleID { get; set; }
        public string StateID { get; set; }
        public int SalesTypeID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAdd1 { get; set; }
        public string CustomerAdd2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public int SalesPrice { get; set; }
        public string SalesDate { get; set; }
    }
}
