using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity.Models
{
    public class TeamModel
    {
        public int TeamsID { get; set; }
        public string TeamName { get; set; }
        public int PlayerID { get; set; }
        public int Score { get; set; }
    }
}