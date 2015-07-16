using Hearthstat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hearthstat.Controllers
{
    [RoutePrefix("api/Games")]
    public class GamesController : ApiController
    {
        // Get api/Games lol
        public string Get()
        {
            return "Antti";
        }
        [Route("Match")]
        // POST api/Games/Match
        public string Post()
        {


            return "pippeli";
        }
    }
}
