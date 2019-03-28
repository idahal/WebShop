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
using System.Web.Http.Cors;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]

    public class PlaceOrderController : Controller
    {
        private readonly PlaceOrderService placeorderService;

        public PlaceOrderController(IConfiguration configuration)

        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.placeorderService = new PlaceOrderService(new PlaceOrderRepository(connectionString));
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            var items = placeorderService.Get();
            if (items != null)
            {
                return Ok(items);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            var placeorder = placeorderService.Get(id);
            if (placeorder != null)
            {

                return Ok(placeorder);
            }
            else
            {
                return NotFound();
            }

    }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]PlaceOrder placeorder)
        {
            var result = this.placeorderService.Add(placeorder);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}

