using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;
using ProductsApi.Models;
using MediatR;
using CRUD.Queries;
using CRUD.Commands;


namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator _mediator )
        {
            this.mediator = _mediator;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await mediator.Send(new GetProductListCommand());
            return products;
  
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await mediator.Send(new GetProductByIdQuery() { ID = id });
            if ( product == null )
            {
                return NotFound();
            }
            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }
            await mediator.Send(new UpdateProductCommand(
                product.ID,
                product.Name,
                product.Category,
                product.Price,
                product.Description));
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var newproduct = await mediator.Send(new CreateProductCommand(
                   product.Name,
                   product.Category,
                   product.Price,
                   product.Description));

            return CreatedAtAction("GetProduct", new { id = newproduct.ID }, newproduct);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await mediator.Send(new DeleteProductCommand() { ID = id });
            return NoContent();
        }

    }
}
