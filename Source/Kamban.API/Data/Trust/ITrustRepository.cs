using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kamban.API.Trust
{
    public interface ITrustRepository
    {
        IQueryable<Trust> GetAllTrusts();
        Trust GetTrustByID(int id);
        bool AddNewTrust(Trust trust);
        void Save();
    }
}