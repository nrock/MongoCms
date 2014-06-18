﻿
namespace MongoCms.Data.Entity
{
	public class PriceAdjustment
	{
		public decimal OldPrice { get; set; }
		public decimal NewPrice { get; set; }
		public string Reason { get; set; }

		public PriceAdjustment(AdjustPrice adjustPrice, decimal oldPrice)
		{
			OldPrice = oldPrice;
			NewPrice = adjustPrice.NewPrice;
			Reason = adjustPrice.Reason;
		}

		public string Describe()
		{
			return string.Format("{0} -> {1}: {2}", OldPrice, NewPrice, Reason);

		}
	}
}