using Kamban.API.Data.Forms;
using Kamban.API.Trust;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kamban.API.Controllers
{
    [Authorize]
    public class FormsController : ApiController
    {
        private ITrustRepository _repo;

        public FormsController(ITrustRepository repo)
        {
            _repo = repo;
        }

        #region GET Api
        public IEnumerable<Form> Get()
        {
            return _repo.GetAllForm(User.Identity.Name);
        }

        public Form Get(string formId)
        {
            return _repo.GetFormByFormId(User.Identity.Name, formId);
        }
#endregion

        #region POST Api
        public IHttpActionResult Post([FromBody]Form value)
        {
//            {
//                "Id":"ckindTest",
//	"Title":"TestTitle",
//	"UserId":"TestUserId"
//}

            value.UserId = User.Identity.Name;

            if (_repo.AddNewForm(value) &&
            _repo.Save())
                return Ok();
            return null;
        }
        #endregion
    }
}
