using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity.Models
{
    public class HistoryModel
    {
        public int historyID { get; set; }
        public System.DateTime DateGame { get; set; }
        public int TeamsID { get; set; }

        public  TeamModel Team { get; set; }
    }
}