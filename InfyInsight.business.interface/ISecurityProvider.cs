using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfyInsight.models;

namespace InfyInsight.business.contract
{
    public interface ISecurityProvider
    {
        User LoginUser(string userName, string password);
        User RegisterUser(User user, string password);
    }
}
