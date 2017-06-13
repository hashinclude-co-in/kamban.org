using Delete.Data;
using Delete.Data.Trust;
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

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Registered Date")]
        public string RegisteredDate { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Website")]
        public string WebSite { get; set; }

        [Display(Name = "Home Type")]
        public TrustType HomeType { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<TrustUser> TrustUnregisteredUsers { get; set; }
        public Dictionary<string, List<InventoryItem>> InventoryGroups { get; set; }
    }

    public enum TrustType
    {
        All,
        OldAgeHome,
        ChildHome
    }
}
