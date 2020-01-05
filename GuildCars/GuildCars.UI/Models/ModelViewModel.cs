using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class ModelViewModel
    {
        public IEnumerable<Model> CurrentModels { get; set; }
        public IEnumerable<Make> CurrentMakes { get; set; }
        public Model ModelToAdd { get; set; }
    }
}