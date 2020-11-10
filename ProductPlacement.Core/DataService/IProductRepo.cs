using ProdductPlacement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPlacement.Core.DataService
{
    public interface IProductRepo
    {
        Product Create(Product product);
        IEnumerable<Product> ReadAllProducts(Filter filter = null);
        Product ReadyById(int id);
        Product DeleteProduct(int id);
        int Count();
        Product UpdateProductInDB(Product product);
    }
}
