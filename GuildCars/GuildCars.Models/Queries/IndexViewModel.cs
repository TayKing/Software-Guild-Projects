using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class IndexViewModel
    {
        public IEnumerable<VehicleViewModel> Vehicles { get; set; }
        public IEnumerable<Special> Specials { get; set; }
    }
}
