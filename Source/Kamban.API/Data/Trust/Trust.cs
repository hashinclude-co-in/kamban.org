using Kamban.API.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kamban.API.Trust
{
    public class Trust
    {
        public int ID { get; set; }
        public string TrustName { get; set; }
        public string TrustRegistrationNumber { get; set; }
        public ICollection<Contact> AllContacts { get; set; }
    }
}