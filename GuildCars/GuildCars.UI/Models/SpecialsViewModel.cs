using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class SpecialsViewModel
    {
        public IEnumerable<Special> CurrentSpecials { get; set; }
        public Special SelectedSpecial { get; set; }
    }
}