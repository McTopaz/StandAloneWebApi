using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using WebApiSelfHost.Models;

namespace WebApiSelfHost
{
    class PeopleController : ApiController
    {
        // GET api/values 
        // http://localhost:9000/api/people/
        public IEnumerable<Person> Get()
        {
            return GlobalData.People;
        }

        // GET api/values/5 
        public Person Get(Guid id)
        {
            return GlobalData.People.Where(p => p.Id == id).FirstOrDefault();
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
