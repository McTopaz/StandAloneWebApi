using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities.Models.Library;

namespace Entities.Factories
{
    public class BookFactory
    {
        public static Book Create(string title, string author, string publisher, params (int Pages, int Rows)[] chapters)
        {
            var book = new Book
            {
                Title = title,
                Author = author,
                Publisher = publisher
            };

            for (int i = 0; i < chapters.Length; i++)
            {
                var chapter = chapters[i];
                var pages = new List<Page>();

                for (int j = 0; j < chapter.Pages; j++)
                {
                    var page = new Page { Number = j + 1, Content = RandomPageContent(chapter.Rows) };
                    pages.Add(page);
                }

                book.AddChapter(new Chapter
                {
                    Title = $"Chapter {i}",
                    Pages = pages,
                    LastChapter = i + 1 == chapters.Length
                });
            }

            return book;
        }

        static IReadOnlyList<string> RandomPageContent(int rows)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int length = 32;
            var rnd = new Random();

            var content = new List<string>();

            for (int i = 0; i < rows; i++)
            {
                var line = new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
                content.Add(line);
            }

            return content;
        }
    }
}
