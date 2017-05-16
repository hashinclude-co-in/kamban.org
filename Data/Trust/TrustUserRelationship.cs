using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delete.Data
{
    public class TrustUserRelationship
    {
        public int Id { get; set; }
        public int TrustID { get; set; }
        public string UserID { get; set; }
        public string Role { get; set; }
        public int Rating { get; set; }
    }
}