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


        public List<Cart> Get()
        {
            {
                return this.cartRepository.Get();
            }
        }


        public Cart Get(int id)
        {
            return this.cartRepository.Get(id);
        }

        public bool Add(int id)
        {

            if (id > 0)
            {
                cartRepository.Add(id);
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
