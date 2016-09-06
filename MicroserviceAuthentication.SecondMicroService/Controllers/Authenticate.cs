using MicroserviceAuthentication.FirstMicroService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MicroserviceAuthentication.SecondMicroService.Controllers
{
    public class Authenticate
    {
        public static bool Auth(string Token)
        {
            var dataFile = "c:\\temp\\accesstoken.txt";
            var data = File.ReadAllText(@dataFile);
            var response = JsonConvert.DeserializeObject<TokenStore>(data);
            if (response.token == Token)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}