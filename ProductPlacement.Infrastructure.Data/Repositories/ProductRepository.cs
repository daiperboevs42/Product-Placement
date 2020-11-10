using Microsoft.EntityFrameworkCore;
using ProdductPlacement.Core.Entity;
using ProductPlacement.Core.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductPlacement.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepo
    {
        private ProductPlacementAppContext _ctx;

        public ProductRepository(ProductPlacementAppContext ctx)
        {
            _ctx = ctx;
        }
        public int Count()
        {
            return _ctx.Products.Count();
        }

        public Product Create(Product product)
        {
            var prod = _ctx.Add(product).Entity;
            _ctx.SaveChanges();
            return prod;
        }

        public Product DeleteProduct(int id)
        {
            Product prod = ReadyById(id);
            _ctx.Attach(prod).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return prod;
        }

        public IEnumerable<Product> ReadAllProducts(Filter filter)
        {
            if (filter.ItemsPrPage == 0 && filter.CurrentPage == 0)
            {
                return _ctx.Products.Include(pt => pt.ProductType).Include(c => c.Color);
            }
            return _ctx.Products
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public Product ReadyById(int id)
        {
            return _ctx.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product UpdateProductInDB(Product product)
        {
            _ctx.Attach(product).State = EntityState.Modified;
            _ctx.SaveChanges();
            return product;
        }
    }
}
