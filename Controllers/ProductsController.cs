using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SqliteConnection _connection;

        public ProductsController(SqliteConnection connection)
        {
            _connection = connection;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<string>> Get()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Products";

                using (var reader = command.ExecuteReader())
                {
                    var products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add(new() {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        });
                    }

                    return Ok(products);
                }
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<string>> Get(string id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Products WHERE Id = " + id;

                using (var reader = command.ExecuteReader())
                {
                    var products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add(new() {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        });
                    }

                    return Ok(products);
                }
            }
        }        
    }
}
