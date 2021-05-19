using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             from u in context.Users
                             join r in context.Rentals on c.CarId equals r.CarId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorID equals cl.ColorID
                             join uo in context.UserOperationClaims on u.Id equals uo.UserId

                             select new RentalDetailsDto
                             {
                                 RentalId = r.Id,
                                 CarRentDate = r.RentDate,
                                 CarReturnDate = r.ReturnDate,

                                 CarId = c.CarId,
                                 CarModelYear = c.ModelYear,
                                 CarDescription = c.Description,
                                 CarDailyPrice = c.DailyPrice,

                                 BrandName = b.BrandName,

                                 ColorName = cl.ColorName,

                                 CustomerId = r.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return result.ToList();
            }

        }
    }
}
