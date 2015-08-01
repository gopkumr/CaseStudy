using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InfyInsight.business.contract;
using InfyInsight.models;

namespace InfyInsight.api.Controllers
{
    public class SecurityController : ApiController
    {
         private ISecurityProvider _securityProvider;

         public SecurityController(ISecurityProvider securityProvider)
        {
            _securityProvider = securityProvider;
        }

        [HttpGet]
        [Route("api/user")]
        public User LoginUser(string userName, string password)
        {
            return _securityProvider.LoginUser(userName, password);
        }

        [HttpPost]
        [Route("api/user")]
        public User RegisterUser([FromBody]User value, string password)
        {
            return _securityProvider.RegisterUser(value, password);
        }
    }
}
