using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using dotNET6_Dapper.Models;

namespace dotNET6_Dapper.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Stock>> GetStock(string symbol)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                string sqlQuery = $"SELECT * FROM [dbo].[StockList] WHERE Symbol = '{symbol}'";
                var result = await connection.QueryAsync<Stock>(sqlQuery);
                Debug.Print(sqlQuery);

                return result;
            }

        }

        public async Task<object> GetStockCount()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                string sqlQuery = "SELECT COUNT(*) FROM [dbo].[StockList]";
                var result = await connection.ExecuteScalarAsync(sqlQuery);

                return result;
            }

        }
        public async Task<IEnumerable<Stock>> GetAllStocks()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM [dbo].[StockList]";
                var result = await connection.QueryAsync<Stock>(sqlQuery);

                return result;
            }
        }
        //public Task<ActionResult> PutProduct(int id, StockDTO productDTO)
        //{
        //    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        string sqlQuery = "INSERT INTO [dbo].[StockList]";
        //        var result = await connection.ExecuteAsync(sqlQuery, entity);
        //        return result;
        //    }
        //}
        //public Task<ActionResult<Stock>> PostProduct(StockDTO productDTO)
        //{
        //    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        return result;
        //    }
        //}
        //public Task<IActionResult> DeleteProduct(int id)
        //{
        //    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        return result;
        //    }
        //}
        //public Task<ActionResult> DeleteMultiple([FromQuery] int[] ids)
        //{
        //    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        return result;
        //    }
        //}

    }
}

/*
 * QueryAsync()
 * QuerySingleOrDefaultAsync()
 * ExecuteAsync
 * 
 * 
 * Declare parameters Option 1 =======================================
 * var parameters = new { UserName = username, Password = password };
 * var sql = "select * from users where username = @UserName and password = @Password";
 * var result = connection.Query(sql, parameters);
 * 
 * Declare parameters Option 2 ========================================
 * var dictionary = new Dictionary<string, object>
    {
        { "@ProductId", 1 }
    };
    var parameters = new DynamicParameters(dictionary);

 * Declare parameters 3 ================================================
 * var parameters = new DynamicParameters({ 
    Beginning_Date = new DateTime(2017, 1, 1), 
    Ending_Date = new DateTime(2017, 12, 31)
    });
 *
 * Stored Procedure =====================================================
 * 
 * var results = connection.Query(procedure, values, commandType: CommandType.StoredProcedure).ToList();
 *
 */