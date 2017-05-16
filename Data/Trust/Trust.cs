using Delete.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Trust
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string WebSite { get; set; }
        public TrustType HomeType { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }

    public enum TrustType
    {
        All,
        OldAgeHome,
        ChildHome
    }
}
