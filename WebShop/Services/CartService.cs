using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using WebShop.Repositories;

namespace WebShop.Services
{
    public class CartService
    {
        private readonly CartRepository cartRepository;

        public CartService(CartRepository itemsRepository)
        {
            this.cartRepository = itemsRepository;
        }


        public List<Cart> Get(Guid guid)
        {
            {
                return this.cartRepository.Get(guid);
            }
        }



        public bool Add(int id, Guid guid)
        {

            if (id > 0)
            {
                cartRepository.Add(id, guid);
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
