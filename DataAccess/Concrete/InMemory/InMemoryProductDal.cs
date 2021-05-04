using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
       List <Car> _car;

        public InMemoryProductDal()
        {
            _car = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorID=1,DailyPrice=450,ModelYear=2020,Description="Az yakar"},
                new Car{CarId=2,BrandId=1,ColorID=1,DailyPrice=250,ModelYear=2015,Description="Çok kaçar"},
                new Car{CarId=3,BrandId=2,ColorID=1,DailyPrice=350,ModelYear=2018,Description="Az yakar çok kaçar"},
                new Car{CarId=4,BrandId=2,ColorID=1,DailyPrice=50,ModelYear=2001,Description="Çalışır durumda"},
                new Car{CarId=5,BrandId=3,ColorID=1,DailyPrice=150,ModelYear=2010,Description="Otoban faresi"},
                new Car{CarId=6,BrandId=3,ColorID=1,DailyPrice=1000,ModelYear=2021,Description="Yer uçağı"}
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
            
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car cartoUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            cartoUpdate.CarId = car.CarId;
            cartoUpdate.BrandId = car.BrandId;
            cartoUpdate.ColorID = car.ColorID;
            cartoUpdate.DailyPrice = car.DailyPrice;
            cartoUpdate.ModelYear = car.ModelYear;
            cartoUpdate.Description = car.Description;
        }
    }
}
