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


        [HttpGet("{guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(Guid guid)
        {
            var result = this.placeorderService.Get(guid);
                          return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post([FromBody]PlaceOrder placeOrder)
        {
            var result = this.placeorderService.Add(placeOrder);

            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }

       
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]

        //public IActionResult Post([FromQuery]string name, string lastname, string address, int zipcode, string city, string cartguid)
        //{
        //    var result = this.placeorderService.Add(name, lastname, address, zipcode, city, cartguid);

        //    if (!result)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok();
        //}


    
}

