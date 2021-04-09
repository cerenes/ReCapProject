using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDatabaseContext>, ICarDal
    {
        public object PathNames { get; private set; }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cr in context.Colors
                             on c.ColorId equals cr.ColorId
                             
                            // let images = (from carImage in context.CarImages where c.Id == carImage.Id select carImage).ToList()
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = cr.ColorName,
                                 DailyPrice = c.DailyPrice,
                                // CarImages = images.Count > 0 ? images : new List<CarImage> { new CarImage { ImagePath = PathNames.CarDefaultImages } }
                             };

                return result.ToList();


            }
        }
    }
}
