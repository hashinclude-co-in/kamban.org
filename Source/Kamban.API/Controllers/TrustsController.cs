using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kamban.API.Trust
{
    public class TrustsController : ApiController
    {
        #region Fields
        ITrustRepository _repo;
        #endregion

        #region Constructor
        public TrustsController(ITrustRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region GET Api
        public IEnumerable<Trust> Get()
        {
            return _repo.GetAllTrusts();

        }
        
        public Trust Get(int id)
        {
            return _repo.GetTrustByID(id);
        }
        #endregion

        #region POST Api
        public void Post([FromBody]Trust value)
        {
            _repo.AddNewTrust(value);
            _repo.Save();
        }
        #endregion
    }
}