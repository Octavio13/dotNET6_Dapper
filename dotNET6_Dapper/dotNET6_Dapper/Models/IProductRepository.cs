using Microsoft.AspNetCore.Mvc;
using PVSRCC_API_Demo.Models.HSport;

namespace dotNET6_Dapper.Models
{
    public interface IProductRepository
    {
        Task<IEnumerable<Stock>> GetStock(string symbol);
        Task<object> GetStockCount();
        Task<IEnumerable<Stock>> GetAllStocks();
        //Task<ActionResult> PutProduct(int id, StockDTO productDTO);
        //Task<ActionResult<Stock>> PostProduct(StockDTO productDTO);
        //Task<IActionResult> DeleteProduct(int id);
        //Task<ActionResult> DeleteMultiple([FromQuery] int[] ids);
    }
}
