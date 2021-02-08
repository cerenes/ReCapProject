using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            ColorTest();
            BrandTest();
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Mercedes" });
            brandManager.Delete(new Brand { BrandId = 6 });
            brandManager.Update(new Brand { BrandId = 6, BrandName = "Rolls Royce" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Purple" });
            colorManager.Delete(new Color { ColorId = 6 });
            colorManager.Update(new Color { ColorId = 7, ColorName="Pink"});
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 1,
                Id = 5,
                ColorId = 1,
                DailyPrice = 40000,
                Description = "Honda",
                ModelYear = 2000
            });
            carManager.Delete(new Car
            {
                Id = 14
            });
           
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
            }
            carManager.GetById(8);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id + " " + car.BrandName + " " + car.ColorName);
            }
        }


    }
}
