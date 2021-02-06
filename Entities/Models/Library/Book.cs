using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Library
{
    public class Book : IBook
    {
        const int AccessTime = 100; // ms

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Bookmark { get; private set; } = 0;
        List<Chapter> Chapters { get; } = new List<Chapter>();

        public void StartFromBeginning()
        {
            Bookmark = 0;
        }

        public void AddChapter(Chapter chapter)
        {
            Chapters.Add(chapter);
        }

        public Chapter GetCurrentChapter()
        {
            var current = Chapters[Bookmark];
            Bookmark = Bookmark < Chapters.Count ? ++Bookmark : 0;
            return current;
        }

        public async Task<Chapter> GetCurrentChapterAsync()
        {
            var chapter = GetCurrentChapter();
            var delay = AccessTime * chapter.Pages.Sum(p => p.Content.Count);
            await Task.Delay(delay);
            return chapter;
        }
    }

    public interface IBook
    {
        Guid Id { get; }
        string Title { get; }
        string Author { get; }
        string Publisher { get; }
        void StartFromBeginning();
        Chapter GetCurrentChapter();
        Task<Chapter> GetCurrentChapterAsync();
    }
}
