using Delete.Data;
using Delete.Data.Trust;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class TrustRepository
    {
        TrustContext _ctx;
        public TrustRepository(TrustContext ctx)
        {
            _ctx = ctx;
        }

        #region Trust Related
        public bool AddTrust(Trust trust)
        {
            try
            {
                _ctx.Trusts.Add(trust);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<Trust> GetAllTrust()
        {
            return _ctx.Trusts.Include("Events");
        }

        public IQueryable<Trust> GetAllTrustByLocation(string location)
        {
            return _ctx.Trusts.Where(x => x.Location == location);
        }

        public bool AddEvent(Event _event)
        {
            try
            {
                _ctx.Events.Add(_event);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<Event> GetEventByTrustId(int trustId)
        {
            return _ctx.Events
                       .Where(x => x.TrustId == trustId);
        }

        public IQueryable<Review> GetReviewsByTrustId(int trustId)
        {
            return _ctx.Reviews
                       .Where(x => x.TrustId == trustId);
        }

        public int GetLinkedTrustIDWithUserId(string UserID)
        {
            try
            {
                if (_ctx.TrustUserRelationship != null && _ctx.TrustUserRelationship.Count() > 0)
                    return _ctx.TrustUserRelationship
                        .Where(x => x.UserID == UserID)
                        .First()
                        .TrustID;
            }
            catch (Exception e)
            {
                return 0;
            }
            return 0;

        }

        public IQueryable<TrustUserRelationship> GetUserIdLinkedWithTrustId(int trustID)
        {
            return _ctx.TrustUserRelationship
                .Where(x => x.TrustID == trustID);

        }

        public bool LinkTrustIDWithUserId(string userID, int trustID, string role, string group)
        {
            try
            {
                _ctx.TrustUserRelationship
                    .Add(new Delete.Data.TrustUserRelationship()
                    {
                        UserID = userID,
                        TrustID = trustID,
                        Role = role,
                        Group= group
                    });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Trust GetTrustByTrustId(int trustId)
        {
            return _ctx.Trusts
                       .Where(x => x.Id == trustId)
                       .First();
        }
        #endregion

        #region Inventory
        public IQueryable<InventoryItem> GetAllInStockInventoryItems(int trustID)
        {
            return _ctx.InventoryItems
                        .Where(x => x.TrustID == trustID);
        }
        public IQueryable<InventoryItem> GetAllOutOfStockInventoryItems()
        {
            return _ctx.InventoryItems
                .Where(x => x.Quantity <= 0);
        }
        public bool AddNewInStockInventoryItem(InventoryItem inventoryItem)
        {
            try
            {
                _ctx.InventoryItems.Add(inventoryItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateInStockInventoryItem(InventoryItem inventoryItem)
        {
            try
            {
                var item = _ctx.InventoryItems
                               .Where(x => x.Id == inventoryItem.Id);

                if (item.Count() != 0)
                {
                    _ctx.InventoryItems.Remove(item.First());
                    _ctx.InventoryItems.Add(inventoryItem);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal ICollection<TrustUser> GetUnRegisteredUsersFromTrustId(int _trustId)
        {
            var item = _ctx.Trusts.Include("TrustUnregisteredUsers").Where(x => x.Id == _trustId).First();
            return item.TrustUnregisteredUsers;
        }

        public bool RemoveInStockInventoryItem(int inventoryItemId)
        {
            try
            {
                var item = _ctx.InventoryItems
                               .Where(x => x.Id == inventoryItemId);

                if (item.Count() != 0)
                {
                    _ctx.InventoryItems.Remove(item.First());
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal bool AddUnRegisteredUserToTrustId(TrustUser trustUser)
        {
            try
            {
                var item = _ctx.Trusts.Where(x => x.Id == trustUser.TrustId).First();
                _ctx.TrustUsers.Add(trustUser);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

    }
}
