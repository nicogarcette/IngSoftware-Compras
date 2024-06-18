using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly string connectionString = "your_connection_string_here";

        [HttpGet("products")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            List<Product> products = new List<Product>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            Id = reader.GetInt32("ProductId"),
                            Name = reader.GetString("Name"),
                            Price = reader.GetDecimal("Price"),
                            StockCurrent = reader.GetInt32("StockCurrent"),
                            StockMin = reader.GetInt32("StockMin"),
                            ImageUrl = reader.GetString("ImageUrl")
                        };
                        products.Add(product);
                    }
                }
            }
            return Ok(products);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockCurrent { get; set; }
        public int StockMin { get; set; }
        public string ImageUrl { get; set; }
    }
}
