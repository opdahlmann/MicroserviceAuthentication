using MicroserviceAuthentication.Autenticate.Models;
using MicroserviceAuthentication.Autenticate.Service;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MicroserviceAuthentication.Autenticate.provider
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;
                var userService = new UserService();
                User user = userService.GetUserByCredentials(username, password);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim("UserID", user.Id)
                    };

                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }
            });
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            var dataFile = "c:\\temp\\accesstoken.txt";
            TokenStore data = new TokenStore() { token = context.AccessToken, UserId = context.Identity.Claims.Last().Value };
            //  responseData = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            File.WriteAllText(@dataFile, JsonConvert.SerializeObject(data));
            return base.TokenEndpointResponse(context);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}