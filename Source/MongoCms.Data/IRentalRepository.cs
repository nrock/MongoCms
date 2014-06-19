using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MongoCms.Entity;

namespace MongoCms.Data
{
    public interface IRentalRepository
    {
        void Save(MongoCms.Entity.Rental rental);
        void Insert(MongoCms.Entity.Rental rental);

        MongoCms.Entity.Rental FindById(string id);


        IList<MongoCms.Entity.Rental> List();



    }
}
