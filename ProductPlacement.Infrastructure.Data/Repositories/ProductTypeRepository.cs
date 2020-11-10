using Microsoft.EntityFrameworkCore;
using ProdductPlacement.Core.Entity;
using ProductPlacement.Core.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductPlacement.Infrastructure.Data.Repositories
{
    public class ProductTypeRepository : IProductTypeRepo
    {
        private ProductPlacementAppContext _ctx;

        public ProductTypeRepository(ProductPlacementAppContext ctx)
        {
            _ctx = ctx;
        }
        public int Count()
        {
            return _ctx.ProductTypes.Count();
        }

        public ProductType Create(ProductType productType)
        {
            var prodType = _ctx.Add(productType).Entity;
            _ctx.SaveChanges();
            return prodType;
        }

        public ProductType DeleteProductType(int id)
        {
            var prodType = ReadyById(id);
            _ctx.Attach(prodType).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return prodType;
        }

        public IEnumerable<ProductType> ReadAllProductTypes(Filter filter)
        {
            if (filter.ItemsPrPage == 0 && filter.CurrentPage == 0)
            {
                return _ctx.ProductTypes;
            }
            return _ctx.ProductTypes
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public ProductType ReadyById(int id)
        {
            return _ctx.ProductTypes.FirstOrDefault(pt => pt.Id == id);
        }

        public ProductType UpdateProducTypetInDB(ProductType productType)
        {
            _ctx.Attach(productType).State = EntityState.Modified;
            _ctx.SaveChanges();
            return productType;
        }
    }
}
