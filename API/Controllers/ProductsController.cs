using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//controller for response to requests 
namespace API.Controllers {

    [ApiController]
    [Route ("api/[controller]")]
    public class ProductsController : ControllerBase {
        private readonly IProductRepository _repository;

        // inject storeContext service to constructor
        public ProductsController (IProductRepository repository) {
            _repository = repository;
        }

        // get list of products from repository
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts () {
            var products = await _repository.GetProductsAsync ();
            return Ok (products);
        }

        // get product from repository using its id
        [HttpGet ("{id}")]
        public async Task<ActionResult<Product>> GetProduct (int id) {
            var product = await _repository.GetProductByIdAsync (id);
            if (product != null) {
                return product;
            }
            return NotFound ();
        }

        [HttpGet ("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands () {
            return Ok (await _repository.GetProductBrandsAsync ());
        }

        [HttpGet ("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes () {
            return Ok (await _repository.GetProductTypesAsync ());
        }
    }
}