using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Funq;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceModel.Serialization;
using ServiceStack.WebHost.Endpoints;

namespace try_servicestack
{
    public class Global : System.Web.HttpApplication
    {

        public class UserAppHost : AppHostBase
        {
            public UserAppHost() : base("User service host", typeof(UserService).Assembly)
            {
                var config = new EndpointHostConfig
                                 {
                                     EnableFeatures = Feature.Json | Feature.Html,
                                     DefaultContentType = ContentType.Json,
                                     DefaultRedirectPath = "/users"
                                 };
                this.SetConfig(config);
                JsonDataContractSerializer.UseSerializer(new JsonNetSerializer());
            }

            public override void Configure(Container container)
            {
                Routes
                    .Add<UserRequest>("/users", "GET")
                    .Add<UserRequest>("/users/{Email}", "GET");
            }
        }

        void Application_Start(object sender, EventArgs e)
        {
            new UserAppHost().Init();
        }

        void Application_End(object sender, EventArgs e)
        {
        }

        void Application_Error(object sender, EventArgs e)
        {
        }

        void Session_Start(object sender, EventArgs e)
        {
        }

        void Session_End(object sender, EventArgs e)
        {
        }

    }
}
