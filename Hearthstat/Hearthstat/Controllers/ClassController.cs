using Hearthstat.Models;
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

        public List<Class> Get()
        {

            using (var dbx = new HeartstatDBDataContext())
            {
                var classes = from c in dbx.Classes
                              select c;

                List<Class> allClasses = classes.ToList();
                return allClasses;
            }

        }

    }
}
