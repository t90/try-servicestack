using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace try_servicestack
{
    [Route("/users*name={Name}")]
    [Route("/users*lastname={LastName}")]
    [Route("/users*firstname={FirstName}")]
    public class UserRequest : User, IReturn<List<User>>
    {
        public string Name { get; set; }
    }
}