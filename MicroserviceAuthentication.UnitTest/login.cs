using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MicroserviceAuthentication.UnitTest
{
    [TestClass]
    public class login
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public async Task<bool> LogIn()
        {
            string username = "email@domain.com";
            string password = "password";
            HttpClient _httpClient = new HttpClient();
            String Token;
            var loginString = string.Format("grant_type=password&username={0}&password={1}", username, password);
            var loginContent = new StringContent(loginString);
            var tokenResponse = _httpClient.PostAsync("token", loginContent).Result;

            if (tokenResponse.IsSuccessStatusCode)
            {
                // get the user and redirect the user
                var loginResponseContent = await tokenResponse.Content.ReadAsStringAsync();
                var loginJson = JsonConvert.DeserializeObject<dynamic>(loginResponseContent);
                string token = loginJson.access_token;
                Token = token;

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                HttpResponseMessage response = _httpClient.GetAsync("loggedInUser").Result;

                if (response.IsSuccessStatusCode)
                {
                    var LoggedInUser = await response.Content.ReadAsStringAsync();
                    return true;
                }
            }
            else
            {
                var t = "t";
            }

            return false;
        }
    }
}
