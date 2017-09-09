using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kamban.API.Contacts
{
    public class Groups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TrustUserName { get; set; }
        public List<int> UserIds { get; set; }
    }
}