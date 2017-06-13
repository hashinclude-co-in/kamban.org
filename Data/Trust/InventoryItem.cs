using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delete.Data.Trust
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }
        public float OriginalAmount { get; set; }
        public float PurchaseAmount { get; set; }
        public int TrustID { get; set; }
        public string GroupName { get; set; }
    }
}