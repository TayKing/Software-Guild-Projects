using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class MakeViewModel
    {
        public IEnumerable<Make> CurrentMakes { get; set; }
        public Make MakeToAdd { get; set; }

    }
}