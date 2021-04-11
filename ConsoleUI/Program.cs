using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();
            //UserTest();
            //CustomerTest();
            //RentalTest();
        }
        /* private static void BrandTest()
         {
             BrandManager brandManager = new BrandManager(new EfBrandDal());
             brandManager.Add(new Brand { BrandName = "Mercedes" });
             //brandManager.Delete(new Brand { BrandId = 6 });
             brandManager.Update(new Brand { BrandId = 3, BrandName = "Rolls Royce" });
             foreach (var brand in brandManager.GetAll())
             {
                 Console.WriteLine(brand.BrandName);
             }
         }

         private static void ColorTest()
         {
             ColorManager colorManager = new ColorManager(new EfColorDal());
             colorManager.Add(new Color { ColorName = "Purple" });
             //colorManager.Delete(new Color { ColorId = 6 });
             colorManager.Update(new Color { ColorId = 3, ColorName="Pink"});
             foreach (var color in colorManager.GetAll())
             {
                 Console.WriteLine(color.ColorName);
             }

         }*/
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer { CompanyName = "İndirimler" });
            //customerManager.Delete(new Customer { CustomerId = 6 });
            //customerManager.Update(new Customer { CustomerId = 3,CompanyName="Kara Cuma", UserId= 2 });
            var result = customerManager.GetAll();
            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }
        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Sedat" });
            //userManager.Delete(new User { UserId = 6 });
            //userManager.Update(new User { UserId = 3, FirstName="Azize", LastName="Aslan", Email="azize_aslan@hotmail.com"});
            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine(user.FirstName);
            }
        }
        //private static void RentalTest()
        //{
            
        //   // RentalManager rentalManager = new RentalManager(new EfRentalDal());
        //    //rentalManager.Add(new Rental {Id=4 });
        //    //rentalManager.Delete(new Rental {Id = 6 });
        //    //rentalManager.Update(new Rental { RentalId=5, Id=2, CustomerId=1, RentDate=DateTime.Now, ReturnDate=DateTime.Now.AddDays(+2) });
        //    var result = rentalManager.GetAll();
        //    foreach (var rental in result.Data)
        //    {
        //        Console.WriteLine(rental.RentalId);
        //    }
        //}

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            /*carManager.Add(new Car
            {
                BrandId = 1,
                
                ColorId = 2,
                DailyPrice = 40000,
                Description = "Honda",
                ModelYear = 2000
            });
            /*carManager.Delete(new Car
            {
                Id = 14
            });*/
            if (result.Success)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        
        /*foreach (var car in carManager.GetAll())
        {
            Console.WriteLine(car.Id);
        }
        carManager.GetById(5);

        foreach (var car in carManager.GetCarDetails())
        {
            Console.WriteLine(car.Id + " " + car.BrandName + " " + car.ColorName);
        }*/

    }


    }
}
