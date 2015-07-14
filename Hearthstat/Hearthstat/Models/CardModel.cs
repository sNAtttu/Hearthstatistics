using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hearthstat.Models
{
    public class CardModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Health Points")]
        public int HP { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Cards attack power")]
        public int AP { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Cards name")]
        public string name { get; set; }
    }
}