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
        public List<Match> Get(string userClass = "", string opponentClass = "")
        {
            List<Match> allPlayed = new List<Match>();

            using (var dbx = new HeartstatDBDataContext())
            {
                dbx.DeferredLoadingEnabled = false;
                
                if (userClass != "" && opponentClass != "")
                {
                    var AllPlayed = from p in dbx.Matches
                                    where p.OpponentClass == opponentClass && p.UserClass == userClass
                                    select p;

                    allPlayed = AllPlayed.ToList();

                }
                else if (userClass != "")
                {
                    var AllPlayed = from p in dbx.Matches
                                    where p.UserClass == userClass
                                    select p;

                    allPlayed = AllPlayed.ToList();
                }
                else if(opponentClass != "")
                {
                    var AllPlayed = from p in dbx.Matches
                                    where p.OpponentClass == opponentClass
                                    select p;

                    allPlayed = AllPlayed.ToList();

                }

                else
                {
                    var AllPlayed = from p in dbx.Matches
                                    select p;

                    allPlayed = AllPlayed.ToList();
                }
                return allPlayed;
            }
        }



        [Route("save")]
        // POST api/Games/save
        public string PostMatchSave(Match match)
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
                    UserClass = match.UserClass,
                    SubClass = match.SubClass,
                    OpponentClass = match.OpponentClass,
                    OpponentSubClass = match.OpponentSubClass,
                    MatchResult = (bool)match.MatchResult,
                    PlayerRank = (int)match.PlayerRank,
                    Season = (int)match.Season,
                    Created = DateTime.Now,
                    Comment = match.Comment,
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
