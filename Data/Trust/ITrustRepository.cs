using Delete.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public interface ITrustRepository
    {
        IQueryable<Trust> GetAllTrust();
        Trust GetTrustByTrustId(int trustId);
        IQueryable<Trust> GetAllTrustByLocation(string location);

        bool Save();
        IQueryable<Event> GetEventByTrustId(int trustId);
        IQueryable<Review> GetReviewsByTrustId(int trustId);
        bool AddTrust(Trust trust);
        int GetLinkedTrustIDWithUserId(string UserID);
        string GetLinkedUserIdWithTrustId(int trustID);
        bool LinkTrustIDWithUserId(string userID, int trustID, string role);
    }
}
