using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class AddVehicleViewModel
    {
        public Vehicle VehicleToAdd { get; set; }
        public IEnumerable<Make> ListMake { get; set; }
        public IEnumerable<Model> ListModel { get; set; }
        public IEnumerable<BodyStyle> ListBody { get; set; }
        public IEnumerable<Transmission> ListTransmission { get; set; }
        public IEnumerable<Color> ListColor { get; set; }
        public Dictionary<string, bool> ListTypeOptions { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }
        public int VehicleID { get; set; }
    }
}