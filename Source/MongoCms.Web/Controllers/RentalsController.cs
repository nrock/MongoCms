using MongoCms.Data;
using MongoCms.Entity;
using MongoCms.Web.ViewModels;

namespace RealEstate.Rentals
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using App_Start;
	using MongoDB.Bson;
	using MongoDB.Driver.Builders;
	using MongoDB.Driver.GridFS;
	using MongoDB.Driver.Linq;

	public class RentalsController : Controller
	{
	    private IRentalRepository _rentalRepository;

	    public RentalsController()
        {
            this._rentalRepository = new RentalRepository();
	    }

        public RentalsController(IRentalRepository rentalRepository)
        {
            this._rentalRepository = rentalRepository;
        }

        //public readonly MongoCmsContext Context = new MongoCmsContext();
       
	    public ActionResult Index(RentalsFilter filters)
		{
			var rentals = FilterRentals(filters);
	        var model = new RentalsList(rentals);
			return View(model);
		}
 
		private IEnumerable<Rental> FilterRentals(RentalsFilter filters)
		{
/*
			var rentals = new RentalsList(_rentalRepository.List());
			if (filters.MinimumRooms.HasValue)
			{
				rentals = rentals
					.Where(r => r.NumberOfRooms >= filters.MinimumRooms);
			}

			if (filters.PriceLimit.HasValue)
			{
				var query = Query<Rental>.LTE(r => r.Price, filters.PriceLimit);
				rentals = rentals
					.Where(r => query.Inject());
			}
 */
            return _rentalRepository.List();
		}
       
		public ActionResult Post()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Post(PostRental postRental)
		{
			var rental = new Rental(postRental);
            _rentalRepository.Insert(rental);
			return RedirectToAction("Index");
		}

        /*
		public ActionResult AdjustPrice(string id)
		{
			var rental = GetRental(id);
			return View(rental);
		}

		private Rental GetRental(string id)
		{
            var rental = _rentalRepository.FindById(id);
			return rental;
		}

		[HttpPost]
		public ActionResult AdjustPrice(string id, AdjustPrice adjustPrice)
		{
			var rental = GetRental(id);
			rental.AdjustPrice(adjustPrice);
            _rentalRepository.Save(rental);
			return RedirectToAction("Index");
		}
		[HttpPost]
		public ActionResult AdjustPriceUsingModification(string id, AdjustPrice adjustPrice)
		{
			var rental = GetRental(id);
			var adjustment = new PriceAdjustment(adjustPrice, rental.Price);
			var modificationUpdate = Update<Rental>
				.Push(r => r.Adjustments, adjustment)
				.Set(r => r.Price, adjustPrice.NewPrice);
			Context.Rentals.Update(Query.EQ("_id", new ObjectId(id)), modificationUpdate);
			return RedirectToAction("Index");
		}

		public ActionResult Delete(string id)
		{
			Context.Rentals.Remove(Query.EQ("_id", new ObjectId(id)));
			return RedirectToAction("Index");
		}

		public string PriceDistribution()
		{
			return new QueryPriceDistribution()
				.Run(Context.Rentals)
				.ToJson();
		}

		public ActionResult AttachImage(string id)
		{
			var rental = GetRental(id);
			return View(rental);
		}

		[HttpPost]
		public ActionResult AttachImage(string id, HttpPostedFileBase file)
		{
			var rental = GetRental(id);
			if (rental.HasImage())
			{
				DeleteImage(rental);
			}
			StoreImage(file, rental);
			return RedirectToAction("Index");
		}

		private void DeleteImage(Rental rental)
		{
			Context.Database.GridFS.DeleteById(new ObjectId(rental.ImageId));
			rental.ImageId = null;
			Context.Rentals.Save(rental);
		}

		private void StoreImage(HttpPostedFileBase file, Rental rental)
		{
			var imageId = ObjectId.GenerateNewId();
			rental.ImageId = imageId.ToString();
			Context.Rentals.Save(rental);
			var options = new MongoGridFSCreateOptions
			{
				Id = imageId,
				ContentType = file.ContentType
			};
			Context.Database.GridFS.Upload(file.InputStream, file.FileName, options);
		}

		public ActionResult GetImage(string id)
		{
			var image = Context.Database.GridFS
				.FindOneById(new ObjectId(id));
			if (image == null)
			{
				return HttpNotFound();
			}
			return File(image.OpenRead(), image.ContentType);
		}*/
	}
}