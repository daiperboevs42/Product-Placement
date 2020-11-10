using Microsoft.EntityFrameworkCore;
using ProdductPlacement.Core.Entity;
using ProductPlacement.Core.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductPlacement.Infrastructure.Data.Repositories
{
    public class ColorRepository : IColorRepo
    {
        private ProductPlacementAppContext _ctx;

        public ColorRepository(ProductPlacementAppContext ctx)
        {
            _ctx = ctx;
        }
        public int Count()
        {
            return _ctx.Colors.Count();
        }

        public Color Create(Color color)
        {
            var col = _ctx.Add(color).Entity;
            _ctx.SaveChanges();
            return col;
        }

        public Color DeleteColor(int id)
        {
            Color col = ReadyById(id);
            _ctx.Attach(col).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return col;
        }

        public IEnumerable<Color> ReadAllColors(Filter filter = null)
        {
            if (filter.ItemsPrPage == 0 && filter.CurrentPage == 0)
            {
                return _ctx.Colors;
            }
            return _ctx.Colors
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public Color ReadyById(int id)
        {
            return _ctx.Colors.FirstOrDefault(c => c.Id == id);
        }

        public Color UpdateColorInDB(Color color)
        {
            _ctx.Attach(color).State = EntityState.Modified;
            _ctx.SaveChanges();
            return color;
        }
    }
}
