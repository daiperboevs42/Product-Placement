using ProdductPlacement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPlacement.Core.DataService
{
    public interface IProductTypeRepo
    {
        ProductType Create(ProductType productType);
        IEnumerable<ProductType> ReadAllProductTypes(Filter filter = null);
        ProductType ReadyById(int id);
        ProductType DeleteProductType(int id);
        int Count();
        ProductType UpdateProducTypetInDB(ProductType productType);
    }
}
