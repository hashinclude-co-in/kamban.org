using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delete.Data
{
    public class Review
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public int TrustId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
