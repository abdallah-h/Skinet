using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//controller for response to requests 
namespace API.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductsController : ControllerBase {
        private readonly StoreContext _context;

        // inject storeContext service to constructor
        public ProductsController (StoreContext context) {
            _context = context;
        }

        // get list of products from database
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts () {
            var products = await _context.Products.ToListAsync ();
            return Ok (products);
        }

        // get product from database using its id
        [HttpGet ("{id}")]
        public async Task<ActionResult<Product>> GetProduct (int id) {
            var product = await _context.Products.FindAsync (id);
            if (product != null) {
                return product;
            }
            return NotFound ();
        }
    }
}