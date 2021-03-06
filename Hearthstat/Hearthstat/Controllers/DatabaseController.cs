﻿using System;
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
        [Route("matches")]
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
        [Route("classes")]
        public string GetClasses()
        {
            List<string> mainClasses = new List<string> { "Druid", "Hunter", "Mage", "Paladin", "Priest", "Rogue", "Shaman", "Warlock", "Warrior" };

            using (var db = new HeartstatDBDataContext())
            {
                foreach (string mainClass in mainClasses)
                {
                    Class newClassAggro = new Class();
                    newClassAggro.MainClass = mainClass;
                    db.Classes.InsertOnSubmit(newClassAggro);
                } 
                try
                {
                    db.SubmitChanges();
                    return "Database seed completed";
                }
                catch
                {
                    return "Something went wrong";
                }
            }

        }

        [Route("subclasses")]
        public string GetSubClasses()
        {
            List<string> subClasses = new List<string> { "Aggro", "Control", "Ramp", "Miracle", "Tempo", "Hybrid", 
                                                        "Fatigue", "Face", "Freeze", "Midrange", "Mech", "Pirate", 
                                                        "Dragon", "Zoo", "Hand", "Demon" };

            using (var db = new HeartstatDBDataContext())
            {
                foreach (string subClass in subClasses)
                {
                    Decktype newClass = new Decktype();
                    newClass.SubClass = subClass;
                    db.Decktypes.InsertOnSubmit(newClass);
                }
                try
                {
                    db.SubmitChanges();
                    return "Database seed completed";
                }
                catch
                {
                    return "Something went wrong";
                }
            }

        }

    }
}
