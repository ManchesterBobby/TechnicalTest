using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TechnicalTest.Models;

namespace TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderHeader order)
        {
            try
            {
                string dbConnection = @"data source=localhost\SQLEXPRESS;initial catalog=Orders;integrated security=True;";

                using (var con = new SqlConnection(dbConnection))
                    {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO OrderHeaders(OrderCustomerId) output INSERTED.ID VALUES(" + order.OrderCustomerId + ")", con);
                    int headerId = (int)cmd.ExecuteScalar();

                    foreach (var orderLine in order.OrderDetails)
                    {
                        cmd = new SqlCommand("INSERT INTO OrderDetails(HeaderId, ProductId, QuantityOrdered, LineValue) " + 
                            "VALUES(" + headerId + "," + orderLine.ProductId + "," + orderLine.QuantityOrdered + "," + orderLine.LineValue + ")", con);
                        cmd.ExecuteNonQuery();
                    }

                    con.Close();

                    return Ok(headerId);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not create order: {ex.Message}");

            }
        }

    }
}
