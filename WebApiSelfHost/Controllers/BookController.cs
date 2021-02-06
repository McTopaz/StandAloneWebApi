using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using Entities.Models.Library;

namespace WebApiSelfHost.Controllers
{
    public class BookController : ApiController
    {
        public Task<Chapter> Get(Guid id)
        {
            var book = GlobalData.Library.Books.First(b => b.Id == id);
            return book.GetCurrentChapterAsync();
        }
    }
}
