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
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductType>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_productTypeService.GetFilteredProductType(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProductType> Get(int id)
        {
            if (id < 1) return BadRequest("ID must be greater than 0");
            if (_productTypeService.GetProductTypeWithId(id) == null) return BadRequest("Could not find Pet with that ID");
            return _productTypeService.GetProductTypeWithId(id);
        }

        [HttpPost]
        public ActionResult<ProductType> Post([FromBody] ProductType productType)
        {
            try
            {
                return Ok(_productTypeService.CreateProductType(productType));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ProductType> Put(int id, [FromBody] ProductType productType)
        {
            if (id < 1 || id != productType.Id) return BadRequest("Parameter ID and PetID does not match");

            return Ok(_productTypeService.UpdateProductType(productType));
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductType> Delete(int id)
        {
            var prod = _productTypeService.RemoveProductType(id);
            if (prod == null) return StatusCode(404, "Did not find Product with ID " + id);
            return Ok($"Product with Id: {id} has been deleted");
        }
    }
}
