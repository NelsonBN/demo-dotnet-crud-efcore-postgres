using Demo.Api.Infrastructure;
using Demo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly DatabaseContext _context;

    public ProductsController(DatabaseContext dbContenxt)
        => _context = dbContenxt;

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _context
            .Products
            .Select(product => (ProductResponse)product)
            .ToList();

        return Ok(products);
    }

    [HttpGet("{id}", Name = nameof(GetProduct))]
    public async Task<IActionResult> GetProduct(uint id)
    {
        if(await _context.Products.FindAsync(id) is Product product)
        {
            return Ok((ProductResponse)product);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductRequest request)
    {
        var product = Product.Create(
            request.Name,
            request.Price);

        _context.Add(product);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.Id.ToString() },
            (ProductResponse)product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(uint id, [FromBody] ProductRequest request)
    {
        if(await _context.Products.FindAsync(id) is Product product)
        {
            product.Name = request.Name;
            product.Price = request.Price;

            _context.Update(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(uint id)
    {
        if(await _context.Products.FindAsync(id) is Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        return NoContent();
    }
}
