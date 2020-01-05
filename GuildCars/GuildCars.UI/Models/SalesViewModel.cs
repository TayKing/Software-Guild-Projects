using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class SalesViewModel
    {
        public Sales Sales { get; set; }
        public IEnumerable<State> States { get; set; }
        public IEnumerable<SalesType> Types { get; set; }
        public VehicleViewModel Vehicle { get; set; }
    }
}