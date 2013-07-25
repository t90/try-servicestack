using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace try_servicestack
{
    [Route("/users*Name={Name}")]
    public class UserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}