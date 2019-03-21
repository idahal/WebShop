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
        private readonly PlaceOrderRepository placeorderRepository;
        
        public PlaceOrderService(PlaceOrderRepository placeorderRepository)
        {
            this.placeorderRepository = placeorderRepository;
        }


        public List<PlaceOrder> Get()
        {
            {
                return this.placeorderRepository.Get();
            }
        }


        public PlaceOrder Get(int id)
        {
            return this.placeorderRepository.Get(id);
        }

        public bool Add(PlaceOrder placeorder)
        {

            if (placeorder != null)
            {
                placeorderRepository.Add(placeorder);
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
