﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.Id));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.ImagesId == carImageId));
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetImagesByCarId(int Id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(Id));
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.ImagesId == carImage.ImagesId).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();

        }
        private IResult CheckImageLimitExceeded(int id)
        {
            var carImagecount = _carImageDal.GetAll(p => p.Id == id).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\bos.jpg";
            var result = _carImageDal.GetAll(c => c.Id == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { Id = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.Id == id);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

    }
}
