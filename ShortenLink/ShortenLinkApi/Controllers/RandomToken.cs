using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShortenLinkApi.AuthService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortenLinkApi.Controllers
{
    public class RandomToken
    {
        private IConfiguration _config;

        public RandomToken(IConfiguration config)
        {
            _config = config;
        }

        //public string GetRandomToken()
        //{
        //    //var jwt = new JWTService(_config);
        //    //var token = jwt.GenerateSecurityToken("fake@email.com", "test");
        //    //return token;
        //}
    }
}
