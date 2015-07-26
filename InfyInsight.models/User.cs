using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfyInsight.models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
