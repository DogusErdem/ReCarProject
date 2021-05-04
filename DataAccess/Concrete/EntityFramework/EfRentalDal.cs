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
                             join r in context.Rentals on c.CarId equals r.CarId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorID equals cl.ColorID
                             join u in context.Users on r.CustomerId equals u.UserId

                             select new RentalDetailsDto
                             {
                                 RentalId = r.UserId,
                                 CarRentDate = r.RentDate,
                                 CarReturnDate = r.ReturnDate,

                                 CarId = c.CarId,
                                 CarModelYear = c.ModelYear,
                                 CarDescription = c.Description,
                                 CarDailyPrice = c.DailyPrice,

                                 BrandName = b.BrandName,

                                 ColorName = cl.ColorName,

                                 CustomerId = u.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return result.ToList();
            }

        }
    }
}
