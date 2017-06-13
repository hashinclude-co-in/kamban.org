using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delete.Models
{
    public class VolunteerViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public float Rating { get; set; }
        public string GroupName { get; set; }
    }

    public class InventoryViewModel
    {
        public string Name { get; set; }
        public float OriginalAmount { get; set; }
        public float PurchaseAmount { get; set; }
        public string GroupName { get; set; }
        public float Quantity { get; set; }
        
    }

    public class ContactViewModel
    {
        public string Name { get; set; }
        public string MailId { get; set; }
        public string PhoneNumber { get; set; }
    }
    }