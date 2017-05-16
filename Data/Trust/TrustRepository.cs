using Delete.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class TrustRepository : ITrustRepository
    {
        TrustContext _ctx;
        public TrustRepository(TrustContext ctx)
        {
            _ctx = ctx;
        }

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

        public string GetLinkedUserIdWithTrustId(int trustID)
        {
            return _ctx.TrustUserRelationship
                .Where(x => x.TrustID == trustID)
                .First()
                .UserID;

        }

        public bool LinkTrustIDWithUserId(string userID, int trustID, string role)
        {
            try
            {
                _ctx.TrustUserRelationship
                    .Add(new Delete.Data.TrustUserRelationship()
                    {
                        UserID = userID,
                        TrustID = trustID,
                        Role = role
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

    }
}
