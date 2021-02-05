using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Library
{
    public class Library
    {
        public List<Book> Books { get; } = new List<Book>();
    }
}
