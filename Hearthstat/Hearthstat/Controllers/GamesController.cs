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
        public List<Match> Get()
        {
            using (var dbx = new HeartstatDBDataContext())
            {
                dbx.DeferredLoadingEnabled = false;

                var AllPlayed = from p in dbx.Matches
                                select p;

                List<Match> allPlayed = AllPlayed.ToList();

                return allPlayed;
            }
        }

        [Route("save")]
        // POST api/Games/save
        public string PostMatchSave([FromBody] dynamic match)
        {
            string username = "Santoro";
            using (var DBContext = new HeartstatDBDataContext())
            {
                var User = from u in DBContext.AspNetUsers
                                  where u.UserName == System.Web.HttpContext.Current.User.Identity.Name
                                  select u.UserName;

                if (User.FirstOrDefault() != null)
                {
                    username = User.FirstOrDefault();
                }                 
       
                Match matchToBeSaved = new Match
                {
                    User = username,
                    UserClass = match.UserClass.Value,
                    SubClass = match.SubClass.Value,
                    OpponentClass = match.OpponentClass.Value,
                    OpponentSubClass = match.OpponentSubClass.Value,
                    MatchResult = (bool)match.MatchResult.Value,
                    PlayerRank = (int)match.PlayerRank.Value,
                    Season = (int)match.Season.Value,
                    Created = DateTime.Now,
                    Comment = match.Comment.Value,
                    UserId = "112111-11111-1111-1111"

                };
                DBContext.Matches.InsertOnSubmit(matchToBeSaved);

                try
                {
                    DBContext.SubmitChanges();
                    return "Game Saved";
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
