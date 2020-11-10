using ProdductPlacement.Core.Entity;
using ProductPlacement.Core.DataService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductPlacement.Core.AppService.Service
{
    public class ProductTypeService : IProductTypeService
    {
        private IProductTypeRepo _productTypeRepo;

        public ProductTypeService(IProductTypeRepo productTypeRepo)
        {
            _productTypeRepo = productTypeRepo;
        }

        public ProductType CreateProductType(ProductType productType)
        {
            return _productTypeRepo.Create(productType);
        }

        public IEnumerable<ProductType> GetAllProductTypes()
        {
            return _productTypeRepo.ReadAllProductTypes();
        }

        public IEnumerable<ProductType> GetFilteredProductType(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPage must be zero or above");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _productTypeRepo.Count())
            {
                throw new InvalidDataException("Index is out of bounds");
            }

            return _productTypeRepo.ReadAllProductTypes(filter);
        }

        public ProductType GetProductTypeWithId(int id)
        {
            return _productTypeRepo.ReadyById(id);
        }

        public ProductType RemoveProductType(int id)
        {
            return _productTypeRepo.DeleteProductType(id);
        }

        public ProductType UpdateProductType(ProductType productTypeToUpdate)
        {
            var prodType = GetProductTypeWithId(productTypeToUpdate.Id);
            prodType.Name = productTypeToUpdate.Name;
            _productTypeRepo.UpdateProducTypetInDB(prodType);
            return prodType;
        }
    }
}
