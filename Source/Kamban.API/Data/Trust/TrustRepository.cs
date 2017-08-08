using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kamban.API.Trust
{
    public class TrustRepository : ITrustRepository
    {
        #region Fields
        TrustContext _ctx;
        #endregion

        #region Constructor
        public TrustRepository(TrustContext ctx)
        {
            _ctx = ctx;
        }
        #endregion

        #region Public Methods
        public bool AddNewTrust(Trust trust)
        {
            _ctx.Trusts.Add(trust);
            return true;
        }
        public IQueryable<Trust> GetAllTrusts()
        {
            return _ctx.Trusts;
        }

        public Trust GetTrustByID()
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            _ctx.SaveChanges();
        }
        #endregion
    }
}