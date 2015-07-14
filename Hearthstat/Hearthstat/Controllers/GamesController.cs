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
        // Get api/Games
        public string Get()
        {
            return "Antti";
        }
        // POST api/Games
        public string Post([FromBody]dynamic newCard)
        {
            try
            {
                CardModel card = new CardModel
                {
                    AP = newCard.AP.Value,
                    HP = newCard.HP.Value,
                    name = newCard.name.Value
                };
                return "New card with name " + card.name + " has been added";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
