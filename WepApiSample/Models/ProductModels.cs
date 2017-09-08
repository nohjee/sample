using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WepApiSample.Models
{
    public class ProductModels
    {
        public int ProductModelsID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductEntity
    {
        public int ProductModelsID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}