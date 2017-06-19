using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace EZOper.TechTester.EZWebTemplate.Areas.ZApi.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET /api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "Value", DateTime.Now.Ticks.ToString() };
        }

        // GET /api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST /api/values
        public void Post(string value)
        {
        }

        // PUT /api/values/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/values/5
        public void Delete(int id)
        {
        }
    }
}