using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Market.Api.Resources;
using Market.Core.Models;
using Market.Core.Services;

namespace Market.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            this._mapper = mapper;
            this._productService = productService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _productService.GetAllWithCategory();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(productResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResource>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<ProductResource>> CreateProduct(
            [FromBody] SaveProductResource saveProductResource)
        {
          
            var productToCreate = _mapper.Map<SaveProductResource, Product>(saveProductResource);

            var newProduct = await _productService.CreateProduct(productToCreate);

            var product = await _productService.GetProductById(newProduct.Id);

            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResource>> UpdateProduct(int id,
            [FromBody] SaveProductResource saveProductResource)
        {
         
            var productToBeUpdate = await _productService.GetProductById(id);

            if (productToBeUpdate == null)
                return NotFound();

            var product = _mapper.Map<SaveProductResource, Product>(saveProductResource);

            await _productService.UpdateProduct(productToBeUpdate, product);

            var updatedProduct = await _productService.GetProductById(id);
            var updatedProductResource = _mapper.Map<Product, ProductResource>(updatedProduct);

            return Ok(updatedProductResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var product = await _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            await _productService.DeleteProduct(product);

            return NoContent();
        }
    }
}