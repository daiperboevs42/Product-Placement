using ProdductPlacement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPlacement.Core.AppService
{
    public interface IProductService
    {
        Product CreateProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductWithId(int id);
        Product RemoveProduct(int id);
        Product UpdateProduct(Product productToUpdate);
        IEnumerable<Product> GetFilteredProduct(Filter filter);
    }
}
