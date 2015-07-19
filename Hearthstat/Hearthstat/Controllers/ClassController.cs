using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hearthstat.Controllers
{
    [RoutePrefix("api/Class")]
    public class ClassController : ApiController
    {

        public void Get()
        {
            List<string> mainClasses = new List<string>();
            List<string> subClasses = new List<string>();
        }
        
    }
}
