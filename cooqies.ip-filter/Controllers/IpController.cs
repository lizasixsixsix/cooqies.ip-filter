using System;
using System.Web.Http;
using cooqies.ip_filter.Filters;

namespace cooqies.ip_filter.Controllers
{
    public class IpController : ApiController
    {
        // GET: Ip
        [IpFilter]
        [AcceptVerbs("GET")]
        public IHttpActionResult Index()
        {
            string ip = String.Empty;
            object _ip;

            if (Request.Properties.TryGetValue("Ip", out _ip))
            {
                ip = (string)_ip;
            }

            return Ok(ip);
        }
    }
}
