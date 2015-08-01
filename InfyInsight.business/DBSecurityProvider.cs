using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfyInsight.business.contract;
using InfyInsight.store;

namespace InfyInsight.business
{
    public class DBSecurityProvider : ISecurityProvider
    {
        private readonly IStoreRepository _storeRepository;
        public DBSecurityProvider(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public models.User LoginUser(string userName, string password)
        {
            return _storeRepository.LoginUser(userName, password);
        }

        public models.User RegisterUser(models.User user, string password)
        {
            return _storeRepository.RegisterUser(user, password);
        }
    }
}
