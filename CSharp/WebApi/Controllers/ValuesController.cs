using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> SomeMethod()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/Values/SubValues")]
        public IEnumerable<string> GetSubValues()
        {
            return new string[] { "SubValue1", "SubValue2" };
        }

        // GET api/values/5
        public string Get(int id, string param1)
        {
            return $"value: {param1}";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
