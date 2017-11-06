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
        public string Name { get; set; }
        public string UserName { get; set; }
        public string RegistrationNumber { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}