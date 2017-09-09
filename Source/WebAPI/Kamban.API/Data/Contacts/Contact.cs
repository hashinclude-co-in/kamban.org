using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kamban.API.Contacts
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailID { get; set; }
        public string Website { get; set; }
        public string Role { get; set; }
        public List<string> Groups { get; set; }
        public string RegisteredUserId { get; set; }

        public string TrustUserName { get; set; }

    }
}