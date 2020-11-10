using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProdductPlacement.Core.Entity;
using ProductPlacement.Core.AppService;

namespace ProductPlacement.UI.ProductRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Color>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_colorService.GetFilteredColor(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Color> Get(int id)
        {
            if (id < 1) return BadRequest("ID must be greater than 0");
            if (_colorService.GetColorWithId(id) == null) return BadRequest("Could not find Pet with that ID");
            return _colorService.GetColorWithId(id);
        }

        [HttpPost]
        public ActionResult<Color> Post([FromBody] Color color)
        {
            try
            {
                return Ok(_colorService.CreateColor(color));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Color> Put(int id, [FromBody] Color color)
        {
            if (id < 1 || id != color.Id) return BadRequest("Parameter ID and PetID does not match");

            return Ok(_colorService.UpdateColor(color));
        }

        [HttpDelete("{id}")]
        public ActionResult<Color> Delete(int id)
        {
            var prod = _colorService.RemoveColor(id);
            if (prod == null) return StatusCode(404, "Did not find Product with ID " + id);
            return Ok($"Product with Id: {id} has been deleted");
        }
    }
}
