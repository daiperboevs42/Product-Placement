using ProdductPlacement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPlacement.Core.DataService
{
    public interface IColorRepo
    {
        Color Create(Color color);
        IEnumerable<Color> ReadAllColors(Filter filter = null);
        Color ReadyById(int id);
        Color DeleteColor(int id);
        int Count();
        Color UpdateColorInDB(Color color);
    }
}
