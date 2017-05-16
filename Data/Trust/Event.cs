using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace WebApplication1.Data
{
    public class Event
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string MapLocation { get; set; }
        public Dictionary<string,string> FAQS { get; set; }
        public int TrustId { get; set; }
        public Dictionary<string, Image> Images { get; set; }
    }
}