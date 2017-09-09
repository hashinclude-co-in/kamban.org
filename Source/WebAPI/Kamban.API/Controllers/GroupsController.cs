using Kamban.API.Contacts;
using Kamban.API.Trust;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kamban.API.Controllers
{
    public class GroupsController : ApiController
    {
        #region Fields
        private ITrustRepository _repo;
        #endregion

        #region Constructor
        public GroupsController(ITrustRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region GET methods
        // GET api/<controller>
        public IEnumerable<string> Get(string userName)
        {
            throw new NotImplementedException();
        }

        // GET api/<controller>/5
        public string Get(string userName, string groupName)
        {
            return "value";
        }

        #endregion

        #region POST methods
        // POST api/<controller>
        public void Post([FromBody]Groups group)
        {
            //_repo.AddNewGroup(group.)
        }
        #endregion

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}