using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
        public class CarImageManager : ICarImageService
        {
            ICarImageDal _carImageDal;
            ICarService _carService;

            private string logoPath = @"\Images\default.jpg";

            public CarImageManager(ICarImageDal carImageDal, ICarService carService)
            {
                _carImageDal = carImageDal;
                _carService = carService;
            }

            public IResult Add(IFormFile file, CarImage carImage)
            {
            //var countOfImage = _carImageDal.GetAll(i => i.CarId == carImage.CarId).Count();
            //if (countOfImage > 4)
            //{
            //    return new ErrorResult(Messages.CarImageLimited);
            //}

            //var carIsExists = _carService.GetById(carImage.CarId);
            //if (!carIsExists.Success)
            //{
            //    return new ErrorResult(Messages.NotFound);
            //}

            //var imageResult = FileHelper.Add(file);
            //if (!imageResult.Success)
            //{
            //    return new ErrorResult(imageResult.Message);
            //}


            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            carImage.Id = default;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);
            }


            //public IResult Update(IFormFile image, CarImage img)
            //{
            //    IResult result = BusinessRules.Run(CheckIfImageIsExists(img.Id),
            //                                   CheckIfFileExtensionValid(image.FileName));
            //    if (result != null)
            //    {
            //        return result;
            //    }
            //    var carImg = _carImageDal.Get(x => x.Id == img.Id);
            //    carImg.Date = DateTime.Now;
            //    carImg.ImagePath = FileHelper.Add(image);
            //    FileHelper.Delete(img.ImagePath);
            //    _carImageDal.Update(carImg);
            //    return new SuccessResult("Image" + Messages.Updated);
            //}

            //public IResult Delete(CarImage img)
            //{
            //    IResult result = BusinessRules.Run(CheckIfImagePathIsExists(img.ImagePath));
            //    if (result != null)
            //    {
            //        return result;
            //    }

            //    _carImageDal.Delete(img);
            //    FileHelper.Delete(img.ImagePath);
            //    return new SuccessResult("Image" + Messages.Deleted);
            //}

            //public IDataResult<CarImage> FindByID(int Id)
            //{
            //    CarImage img = new CarImage();
            //    if (_carImageDal.GetAll().Any(x => x.Id == Id))
            //    {
            //        img = _carImageDal.GetAll().FirstOrDefault(x => x.Id== Id);
            //    }
            //    else Console.WriteLine("No such car image was found.");
            //    return new SuccessDataResult<CarImage>(img);
            //}

            //public IDataResult<CarImage> Get(CarImage img)
            //{
            //    return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.Id== img.Id));
            //}

            //public IDataResult<List<CarImage>> GetAll()
            //{
            //    return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
            //}

            //public IResult GetList(List<CarImage> list)
            //{
            //    Console.WriteLine("\n------- Car Image List -------");

            //    foreach (var img in list)
            //    {
            //        Console.WriteLine("{0}- Car ID: {1}\n    Image Path: {2}\n    Date: {3}\n", img.Id, img.CarId, img.ImagePath, img.Date);
            //    }
            //    return new SuccessResult();
            //}

            //public IDataResult<List<CarImage>> GetCarListByCarID(int carID)
            //{
            //    if (!_carImageDal.GetAll().Any(x => x.CarId == carID))
            //    {
            //        List<CarImage> img = new List<CarImage>
            //        {
            //            new CarImage
            //            {
            //                CarId = carID,
            //                ImagePath = DefaultImage
            //            }
            //        };
            //        return new SuccessDataResult<List<CarImage>>(img);
            //    }
            //    return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(x => x.CarId == carID));
            //}

            //private IResult CheckIfCarIsExists(int carId)
            //{
            //    if (!_carService.GetAll().Data.Any(x => x.CarId == carId))
            //    {
            //        return new ErrorResult(Messages.NotFound + "car");
            //    }
            //    return new SuccessResult();
            //}

            //private IResult CheckIfFileExtensionValid(string file)
            //{
            //    if (!Regex.IsMatch(file, @"([A-Za-z0-9\-]+)\.(png|PNG|gif|GIF|jpg|JPG|jpeg|JPEG)"))
            //    {
            //        return new ErrorResult(Messages.InvalidFileExtension);
            //    }

            //    return new SuccessResult();
            //}

            //private IResult CheckIfImagePathIsExists(string path)
            //{
            //    if (!_carImageDal.GetAll().Any(x => x.ImagePath == path))
            //    {
            //        return new ErrorResult(Messages.NotFound + "image");
            //    }

            //    return new SuccessResult();
            //}

            //private IResult CheckIfImageNumberLimitForCar(int carId)
            //{
            //    if (_carImageDal.GetAll(x => x.CarId == carId).Count == 5)
            //    {
            //        return new ErrorResult(Messages.CarImageLimited);
            //    }
            //    return new SuccessResult();
            //}

            //private IResult CheckIfImageIsExists(int Id)
            //{
            //    if (!_carImageDal.GetAll().Any(x => x.Id == Id))
            //    {
            //        return new ErrorResult(Messages.NotFound + "image");
            //    }
            //    return new SuccessResult();
            //}
        }

    }
