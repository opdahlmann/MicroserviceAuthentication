using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceAuthentication.SecondMicroService.Controllers
{
    public class TestController : ApiController
    {
      [CustomAuthorize]
        public string Get()
        {
           
            return "test";
        }
    }
}
