using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCms.Web.ViewModels
{
    public class RentalViewModel
    {
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
    }
}
