using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using WebShop.Repositories;

namespace WebShop.Services
{
    public class PlaceOrderService
    {
        private readonly PlaceOrderRepository PlaceOrderRepository;
        
        public PlaceOrderService(PlaceOrderRepository placeorderRepository)
        {
            this.PlaceOrderRepository = placeorderRepository;
        }


        public List<PlaceOrder> Get()
        {
            {
                return this.PlaceOrderRepository.Get();
            }
        }

        public PlaceOrder Get(Guid guid)
        {
            return this.PlaceOrderRepository.Get(guid);
        }

        public bool Add(PlaceOrder placeOrder)
        {
            if (placeOrder != null)
            {
                PlaceOrderRepository.Add(placeOrder);
                return true;
            }
            return false;
        }
        
    }
}
