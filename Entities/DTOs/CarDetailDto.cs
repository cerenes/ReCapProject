using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto

    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public decimal DailyPrice { get; set; }
        public List<CarImage> CarImages { get; set; }


    }
}
