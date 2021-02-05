using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Library
{
    public class Chapter : IChapter
    {
        public string Title { get; set; }
        public IReadOnlyList<Page> Pages { get; set; }
        public bool LastChapter { get; set; } = false;
    }

    public interface IChapter
    {
        string Title { get; }
        IReadOnlyList<Page> Pages { get; }
        bool LastChapter { get; }
    }
}
