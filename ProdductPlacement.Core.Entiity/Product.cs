using System;
using System.Collections.Generic;
using System.Text;

namespace ProdductPlacement.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Color Color { get; set; }
        public ProductType ProductType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
