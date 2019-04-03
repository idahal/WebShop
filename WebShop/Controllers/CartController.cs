using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Services;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;
using WebShop.Repositories;


namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly CartService cartService;

        public CartController(IConfiguration configuration)

        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartService = new CartService(new CartRepository(connectionString));
        }
        [HttpGet("{guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(Guid guid)
        {
            var items = cartService.Get(guid);
            if (items != null)
            {
                return Ok(items);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post([FromQuery]int id, int price, string guid = null)
        {
            var cartGuid = Guid.TryParse(guid, out Guid guidresult) ? guidresult : Guid.NewGuid();

            var result = cartService.Add(id, cartGuid, price);

            if (!result)
            {
                return BadRequest();
            }
            return Ok(cartGuid);
        }
    }
}




