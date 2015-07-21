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
        [Route("main")]
        public List<Class> GetMain()
        {
            using (var dbx = new HeartstatDBDataContext())
            {
                var classes = (from c in dbx.Classes
                               select c).ToList();

                List<Class> allClasses = classes;
                return allClasses;
            }
        }

        [Route("sub")]
        public List<Decktype> GetSub()
        {
            using (var dbx = new HeartstatDBDataContext())
            {
                var subClasses = (from c in dbx.Decktypes
                               select c).ToList();

                List<Decktype> allSubClasses = subClasses;
                return allSubClasses;
            }
        }

    }
}
