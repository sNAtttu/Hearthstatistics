using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hearthstat.Controllers
{
    [Authorize]
    [RoutePrefix("api/Database")]
    public class DatabaseController : ApiController
    {
        public string Get()
        {
            using (var DBContext = new HeartstatDBDataContext())
            {
                for(int i = 0; i < 10; i++){

                Match seedMatch = new Match
                {
                    User = "TestUser"+i.ToString(),
                    UserClass = "Druid",
                    SubClass = "Ramp",
                    OpponentClass = "Warlock",
                    OpponentSubClass = "Zoo",
                    MatchResult = false,
                    PlayerRank = 18,
                    Season = 5,
                    Created = DateTime.Now,
                    Comment = "Paska peli",
                    UserId = "1111-1111111-1111-111"
                };
                DBContext.Matches.InsertOnSubmit(seedMatch);
                }
                try
                {
                    DBContext.SubmitChanges();
                    return "Database seed completed";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                
            }
        }
    }
}
