using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceAuthentication.FirstMicroService.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/Test
        public string Get()
        {
            var token = ActionContext.Request.Headers.Authorization.Parameter;
            var dataFile = "c:\\temp\\accesstoken.txt";
            var data = File.ReadAllText(@dataFile);
            var response = JsonConvert.DeserializeObject<TokenStore>(data);
            if (response.token == token)
            {
                return response.UserId;
            }
            return null;
        }
    }
}
