using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class InventoryViewModel
    {
        public List<InventoryReport> NewReports { get; set; }
        public List<InventoryReport> UsedReports { get; set; }
    }
}