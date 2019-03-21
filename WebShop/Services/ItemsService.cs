using System;
using System.Collections.Generic;
using WebShop.Models;
using WebShop.Repositories;

namespace WebShop.Services
{
    public class ItemsService
    {
        private readonly ItemsRepository itemsRepository;
       
        public ItemsService(ItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

     
        public List<Items> Get()
        {
            {
                return this.itemsRepository.Get();
            }
        }


        public Items Get(int id)
        {
            return this.itemsRepository.Get(id);
        }

        public bool Add(Items items)
        {

            if (items != null)
            {
                itemsRepository.Add(items);
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
