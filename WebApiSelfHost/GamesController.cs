using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiSelfHost
{
    [RoutePrefix("game")]
    public class GamesController : ApiController
    {

        // GET api/values 
        // http://localhost:9000/api/values/
        public IEnumerable<string> Get()
        {
            return new string[] { "Mario", "Luigi", "Bowser" };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "Mario " + id;
        }

        // POST api/values 
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}