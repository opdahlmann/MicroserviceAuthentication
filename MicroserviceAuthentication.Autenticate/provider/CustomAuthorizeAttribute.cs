using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;

namespace Microservice.TestMongo.provider
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute

    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)

        {
            //   IPrincipal incomingPrincipal = actionContext.RequestContext.Principal;
            if (AuthorizeRequest(actionContext))

            {
                return;
            }

            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)

        {
            //Code to handle unauthorized request
        }

        private bool AuthorizeRequest(System.Web.Http.Controllers.HttpActionContext actionContext)

        {
            //Write your code here to perform authorization

            return true;
        }
    }
}