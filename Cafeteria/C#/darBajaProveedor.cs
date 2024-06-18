using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly string connectionString = "your_connection_string_here";

        [HttpDelete("deleteProvider/{id}")]
        public IActionResult DeleteProvider(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Providers WHERE ProviderId = @ProviderId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProviderId", id);
                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    return Ok(new { message = "Proveedor eliminado exitosamente" });
                }
                else
                {
                    return NotFound(new { message = "Proveedor no encontrado" });
                }
            }
        }
    }
}
