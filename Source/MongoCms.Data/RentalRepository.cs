using System; 
using MongoDB.Bson; 
using MongoCms.Data.Entity; 
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;


namespace MongoCms.Data
{
    public class RentalRepository: MongoCmsRepository, IRentalRepository
    {


        public void Save(MongoCms.Entity.Rental rental)
        {
            this.Rentals.Save(rental);
        }
        public void Insert(MongoCms.Entity.Rental rental)
        {
            this.Rentals.Insert(rental);
        }

        public IList<MongoCms.Entity.Rental> List()
        {
            //var list = this.Rentals.AsQuerable(); // <MongoCms.Data.Entity.Rental>();


            IQueryable<Rental> rentals = this.Rentals.AsQueryable()
                .OrderBy(r => r.Price);



            return rentals.Select(x => new MongoCms.Entity.Rental
            {
                Address = x.Address,
                //Adjustments = x.Adjustments, 
                Description = x.Description,
                Id = x.Id,
                ImageId = x.ImageId,
                NumberOfRooms = x.NumberOfRooms,
                Price = x.Price 
            }).ToList<MongoCms.Entity.Rental>();
        }

        public MongoCms.Entity.Rental FindById(string id)
        { 
            var rental = this.Rentals.FindOneById(new ObjectId(id));
            return new MongoCms.Entity.Rental
            {
                Address = rental.Address,
                //Adjustments = rental.Adjustments, 
                Description = rental.Description,
                Id =  rental.Id,
                ImageId = rental.ImageId,
                NumberOfRooms = rental.NumberOfRooms,
                Price = rental.Price
            };
        }
        
    }
}