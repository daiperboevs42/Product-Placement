using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdductPlacement.Core.Entity;
using ProductPlacement.Core.AppService;

namespace ProductPlacement.UI.ProductRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_productService.GetFilteredProduct(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            if (id < 1) return BadRequest("ID must be greater than 0");
            if (_productService.GetProductWithId(id) == null) return BadRequest("Could not find Pet with that ID");
            return _productService.GetProductWithId(id);
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            try
            {
                return Ok(_productService.CreateProduct(product));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product product)
        {
            if (id < 1 || id != product.Id) return BadRequest("Parameter ID and PetID does not match");

            return Ok(_productService.UpdateProduct(product));
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var prod = _productService.RemoveProduct(id);
            if(prod == null) return StatusCode(404, "Did not find Product with ID " + id);
            return Ok($"Product with Id: {id} has been deleted");
        }
    }
}
