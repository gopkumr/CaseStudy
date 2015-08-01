using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfyInsight.business.contract;
using InfyInsight.store;

namespace InfyInsight.business
{
    public class OrderManager : IOrderManager
    {
        private readonly IStoreRepository _storeRepository;

        public OrderManager(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public models.Order AddProductToCart(Guid orderId, Guid productId, int quantity)
        {
            return _storeRepository.AddProductToCart(orderId, productId, quantity);
        }

        public models.Order RemoveProductToCart(Guid orderId, Guid productId, int quantity)
        {
            return _storeRepository.RemoveProductToCart(orderId, productId, quantity);
        }

        public bool CheckoutCart(Guid orderId)
        {
            return _storeRepository.CheckoutCart(orderId);
        }
    }
}
