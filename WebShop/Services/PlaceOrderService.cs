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


        public PlaceOrder Get(int id)
        {
            return this.PlaceOrderRepository.Get(id);
        }

        public bool Add(PlaceOrder placeorder)
        {

            if (placeorder != null)
            {
                PlaceOrderRepository.Add(placeorder);
                return true;
            }
            return false;
        }

        internal object Get(object id)
        {
            throw new NotImplementedException();
        }
    }
}
