
namespace MongoCms.Data.Entity
{
	using System.Collections.Generic;

	public class RentalsList
	{
		public IEnumerable<Rental> Rentals { get; set; }
		public RentalsFilter Filters { get; set; }
	}
}