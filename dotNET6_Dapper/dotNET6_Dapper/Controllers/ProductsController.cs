using dotNET6_Dapper.Models;
using Microsoft.AspNetCore.Mvc;
using PVSRCC_API_Demo.Models.HSport;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVSRCC_API_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }
        /* ============================
                     GET
        ============================*/
        //[HttpGet]
        //public IEnumerable<Product> GetAllProducts()
        //{
        //    return _shopContext.Products.ToArray();
        //}

        [HttpGet, Route("GetStock/{symbol}")]
        public async Task<ActionResult<StockDTO>> GetStock(string symbol)
        {
            var stock = await _repository.GetStock(symbol);// Returns specific product or 404 if nothing is found, this way you get JSON information.
            if (stock == null) return NotFound();
            //return ItemToDTO(stock);
            //return Ok(_shopContext.Products.SingleOrDefault(p => p.Id == id)); //Alternative way of returning data or a 204?
            return Ok(stock);
        }

        [HttpGet("GetAllStocks")]
        public async Task<ActionResult<IEnumerable<StockDTO>>> GetAllStocks()
        {
            //_context.TodoItems
            //        .Select(x => ItemToDTO(x))
            //        .ToListAsync();
            var result = await _repository.GetAllStocks();
            //result.Select(x => ItemToDTO(x)).ToArrayAsync();

            return Ok(result);
        }

        /* ============================
                     PUT
        ============================*/
        //[HttpPut("PutProduct/{symbol}")]
        //public async Task<ActionResult> PutProduct(int id, StockDTO productDTO)
        //{
        //    if (id != productDTO.Id) return BadRequest();
        //    if (id == null) return NotFound();

        //    _repository.Entry(product).State = EntityState.Modified;
        //    var todoItem = await _context.TodoItems.FindAsync(id);

        //    product.Name = product.Name;
        //    product.IsComplete = todoItemDTO.IsComplete;


        //    try
        //    {
        //        await _shopContext.SaveChangesAsync();
        //    }
        //    catch( DbUpdateConcurrencyException ) when (!TodoItemExists(id))
        //    {
        //        if (!_shopContext.Products.Any(p => p.Id == id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return NoContent();
        //}
        ///* ============================
        //            POST
        //============================*/
        //[HttpPost("PostProduct")]
        ////There is an issue with this endpoint
        //public async Task<ActionResult<Stock>> PostProduct(StockDTO productDTO)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest();
        //    //}
        //    var product = new Stock
        //    {
        //        Symbol = productDTO.Symbol,
        //        CompanyName = productDTO.CompanyName,
        //        //Id = productDTO.Id,
        //        //Sku = productDTO.Sku,
        //        //Name = productDTO.Name,
        //        //Description = productDTO.Description,
        //        //Price = productDTO.Price,
        //        //IsAvailable = productDTO.IsAvailable,
        //        //CategoryId = productDTO.CategoryId,
        //        //Category = productDTO.Category,
        //    };
        //    _repository.Add(productDTO);
        //    await _repository.SaveChangesAsync();

        //    //return CreatedAtAction(
        //    //nameof(GetTodoItem),
        //    //new { id = todoItem.Id },
        //    //ItemToDTO(todoItem));
        //    return CreatedAtAction("GetProduct"
        //                            , new { id = product.Id }
        //                            , product);
        //}

        ///* ============================
        //            DELETE
        //============================*/
        //[HttpDelete("DeleteProduct/{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    var product = await _repository.FindAsync(id);
        //    if (product == null) return NotFound();

        //    _repository.Remove(product);
        //    await _repository.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpPost]
        //[Route("Delete")]
        //public async Task<ActionResult> DeleteMultiple([FromQuery] int[] ids)
        //{
        //    var products = new List<Stock>();
        //    foreach (var id in ids)
        //    {
        //        var product = await _repository.FindAsync(id);
                
        //        if (product == null)
        //        {
        //            return NotFound();
        //        }

        //        products.Add(product);
        //    }

        //    _repository.RemoveRange(products);
        //    await _repository.SaveChangesAsync();
        //    return Ok(products);
        //}

        //private bool TodoItemExists(long id) =>
        //_repository.Any(e => e.Id == id);

        private static StockDTO ItemToDTO(Stock product) =>
            new StockDTO
            {
                Symbol = product.Symbol,
                CompanyName = product.CompanyName,
                //Id = product.Id,
                //Sku = product.Sku,
                //Name = product.Name,
                //Description = product.Description,
                //Price = product.Price,
                //IsAvailable = product.IsAvailable,
                //CategoryId = product.CategoryId,
                //Category = product.Category,
            };
    }
}


/*
 * There are 3 common ways of transporting data
 * [FromBody]
 * [FromRoute]
 * [FromQuery]
 */