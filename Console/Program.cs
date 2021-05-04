using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandTest();
            //CarTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var results = carManager.GetCarDetails();
            if (results.Success == true)
            {
                foreach (var car in results.Data)
                {
                    Console.WriteLine(car.CarId + "->" + car.BrandName + "->" + car.ColorName + "->" + car.DailyPrice);
                }
            }
            else
                Console.WriteLine(results.Message);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success==true) { 
            foreach (var car in result.Data)
            {
                Console.WriteLine(car);
            }
        }
            else
                Console.WriteLine("");
    }
    }
}
