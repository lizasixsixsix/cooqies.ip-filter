using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace cooqies.ip_filter.Filters
{
    public class IpFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var ip = GetClientIpAddress(actionContext.Request);

            actionContext.Request.Properties.Add(new KeyValuePair<string, object>("Ip", ip));

            base.OnActionExecuting(actionContext);
        }

        private string GetClientIpAddress(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return IPAddress.Parse(((HttpContextBase)request.Properties["MS_HttpContext"]).Request.UserHostAddress).ToString();
            }

            return String.Empty;
        }
    }
}
