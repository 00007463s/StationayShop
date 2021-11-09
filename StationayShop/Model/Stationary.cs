using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationayShop.Model
{
    public class Stationary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int QuantityAvailable { get; set; }

        public string CountryOfProduction { get; set; }

        public int StationaryCategoryId { get; set; }
        public Category StationaryCategory { get; set; }
    }
}
