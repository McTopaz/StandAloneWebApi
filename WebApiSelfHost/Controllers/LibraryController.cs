using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using Entities.Models.Library;

namespace WebApiSelfHost.Controllers
{
    public class LibraryController : ApiController
    {
        public IEnumerable<Book> Get()
        {
            return GlobalData.Library.Books;
        }

        public Book Get(Guid id)
        {
            return GlobalData.Library.Books.FirstOrDefault(b => b.Id == id);
        }
    }
}
