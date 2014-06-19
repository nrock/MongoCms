
using System.Linq;

namespace MongoCms.Web.ViewModels
{
    using MongoCms.Entity;
    using System.Collections.Generic;

	public class RentalsList
	{
	    public RentalsList(IEnumerable<Rental> rentals)
	    {
	        Rentals = rentals;
            Filters = new RentalsFilter();
	    }

		public IEnumerable<Rental> Rentals { get; set; }
		public RentalsFilter Filters { get; set; }
	}
}