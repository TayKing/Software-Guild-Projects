using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class FileLookupResponse : Response
    {
        public string FilePath { get; set; }
        public List<Order> Orders { get; set; }
        public Order Order { get; set; }
        public string OrderDate { get; set; }
    }
}
