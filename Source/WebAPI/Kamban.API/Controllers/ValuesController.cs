using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Kamban.API.Controllers
{
    public class Form1
    {
        public string id;
        public string title;
        public string description;
    }
    public class ValuesController : ApiController
    {
        // GET api/values
        public Form1 Get()
        {
            return new Form1 {id="dummyID", description="dummyDescription",title="dummyTitle" };
        }

        [Authorize]
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post()
        {
            return "CK";
        }
        [Authorize]
        public string Post(int id)
        {
            return "CK";
        }
        
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
