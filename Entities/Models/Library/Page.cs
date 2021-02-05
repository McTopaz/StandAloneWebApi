using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Library
{
    public class Page : IPage
    {
        public int Number { get; set; }
        public IReadOnlyList<string> Content { get; set; }
    }

    public interface IPage
    {
        int Number { get; }
        IReadOnlyList<string> Content { get; }
    }
}
