using ProdductPlacement.Core.Entity;
using ProductPlacement.Core.DataService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductPlacement.Core.AppService.Service
{
    public class ProductService : IProductService
    {
        private IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public Product CreateProduct(Product product)
        {
            return _productRepo.Create(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepo.ReadAllProducts();
        }

        public IEnumerable<Product> GetFilteredProduct(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPage must be zero or above");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _productRepo.Count())
            {
                throw new InvalidDataException("Index is out of bounds");
            }

            return _productRepo.ReadAllProducts(filter);
        }

        public Product GetProductWithId(int id)
        {
            return _productRepo.ReadyById(id);
        }

        public Product RemoveProduct(int id)
        {
            return _productRepo.DeleteProduct(id);
        }

        public Product UpdateProduct(Product productToUpdate)
        {
            var prod = GetProductWithId(productToUpdate.Id);
            prod.Name = productToUpdate.Name;
            prod.Price = productToUpdate.Price;
            prod.Color = productToUpdate.Color;
            prod.CreatedDate = productToUpdate.CreatedDate;
            prod.ProductType = productToUpdate.ProductType;
            _productRepo.UpdateProductInDB(prod);
            return prod;
        }
    }
}
