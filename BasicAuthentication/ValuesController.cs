﻿using _2209.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace _2209.Controllers
{

    [BasicAuthentication]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2", Thread.CurrentPrincipal.Identity.Name };

            //BasicAuthenticationAttribute.CurrentAirline.ToString()};

            //return new string[] { "value1", "value2" , Thread.CurrentPrincipal.Identity.Name,
            //((Airline)Request.Properties["air-line"]).ToString() };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
