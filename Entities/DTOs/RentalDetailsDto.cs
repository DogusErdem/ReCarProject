using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailsDto :IDto
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String BrandName { get; set; }
        public String ColorName { get; set; }
        public int CarModelYear { get; set; }
        public int CarDailyPrice { get; set; }
        public string CarDescription { get; set; }
        public DateTime CarRentDate { get; set; }
        public DateTime CarReturnDate { get; set; }
    }
}
