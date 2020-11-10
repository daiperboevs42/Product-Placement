using ProdductPlacement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPlacement.Core.AppService
{
    public interface IProductTypeService
    {
        ProductType CreateProductType(ProductType productType);
        IEnumerable<ProductType> GetAllProductTypes();
        ProductType GetProductTypeWithId(int id);
        ProductType RemoveProductType(int id);
        ProductType UpdateProductType(ProductType productTypeToUpdate);
        IEnumerable<ProductType> GetFilteredProductType(Filter filter);
    }
}
