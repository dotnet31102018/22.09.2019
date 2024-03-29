﻿using _2209.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace _2209.Controllers
{
    internal class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {

        [ThreadStatic]
        public static Airline CurrentAirline = null;

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //                actionContext.Response = actionContext.Request
            //                          .CreateResponse(HttpStatusCode.Unauthorized);

            //actionContext.RequestContext.Principal
            //Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("itay"), null);
            //actionContext.Request.GetRequestContext().Principal = ...

            
            //CurrentAirline = new Airline { Name = "El Al", Password = "1234" };
            //actionContext.Request.Properties["air-line"] = CurrentAirline;

            string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;

            string decodedAuthenticationToken = Encoding.UTF8.GetString(
                Convert.FromBase64String(authenticationToken));

            string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
            string username = usernamePasswordArray[0];
            string password = usernamePasswordArray[1];

            if (username == "itay" && password == "1234")
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(username), null);
            }
            else
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}