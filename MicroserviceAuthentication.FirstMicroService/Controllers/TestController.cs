using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceAuthentication.FirstMicroService.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/Test
        public IEnumerable<string> Get()
        {
            var token = ActionContext.Request.Headers.Authorization.Parameter;
            return new string[] { "value1", "value2" };
        }
    }
}
