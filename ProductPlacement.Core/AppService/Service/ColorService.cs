using ProdductPlacement.Core.Entity;
using ProductPlacement.Core.DataService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductPlacement.Core.AppService.Service
{
    public class ColorService : IColorService
    {
        private IColorRepo _colorRepo;
        public ColorService(IColorRepo colorRepo)
        {
            _colorRepo = colorRepo;
        }

        public Color CreateColor(Color color)
        {
            return _colorRepo.Create(color);
        }

        public IEnumerable<Color> GetAllColors()
        {
            return _colorRepo.ReadAllColors();
        }

        public Color GetColorWithId(int id)
        {
            return _colorRepo.ReadyById(id);
        }

        public IEnumerable<Color> GetFilteredColor(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPage must be zero or above");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _colorRepo.Count())
            {
                throw new InvalidDataException("Index is out of bounds");
            }

            return _colorRepo.ReadAllColors(filter);
        }

        public Color RemoveColor(int id)
        {
            return _colorRepo.DeleteColor(id);
        }

        public Color UpdateColor(Color colorToUpdate)
        {
            var color = GetColorWithId(colorToUpdate.Id);
            color.Name = colorToUpdate.Name;
            _colorRepo.UpdateColorInDB(color);
            return color;
        }
    }
}
