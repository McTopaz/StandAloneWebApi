using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Entities.Models.Library;
using Newtonsoft.Json;

namespace ConsoleTest
{
    class Library
    {
        public async static Task Run()
        {
            Welcome();
            await AvailableBooks();

        }

        static void Welcome()
        {
            Console.WriteLine("");
            Console.WriteLine("=== Welcome to the library ===============================================================");
            Console.WriteLine("");
        }

        static async Task AvailableBooks()
        {
            Console.WriteLine("");
            Console.WriteLine("These books are available:");
            Console.WriteLine("");

            var books = await GetBooks();
            DisplayBooks(books);
        }

        static async Task<IEnumerable<IBook>> GetBooks()
        {
            var url = "http://localhost:9000/api/library";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
        }

        static void DisplayBooks(IEnumerable<IBook> books)
        {
            Console.WriteLine("+----------------------------------------------------------------------------------------+");
            Console.WriteLine(BookHeader());
            Console.WriteLine("|----------------------------------------------------------------------------------------|");

            for (int i = 0; i < books.Count(); i++)
            {
                var book = books.ElementAt(i);
                Console.WriteLine(BookLine(i, book.Title, book.Author, book.Publisher));
            }

            Console.WriteLine("+----------------------------------------------------------------------------------------+");
            Console.WriteLine("");
        }

        static string BookHeader(int columnLength = 25)
        {
            var i = "#".PadLeft(2);
            var t = "Title".PadRight(columnLength);
            var a = "Author".PadRight(columnLength);
            var p = "Publisher".PadRight(columnLength);
            return $"| {i} | {t} | {a} | {p} | ";
        }

        static string BookLine(int index, string title, string author, string publisher, int columnLength = 25)
        {
            var i = index.ToString().PadLeft(2);
            var t = title.PadRight(columnLength);
            var a = author.PadRight(columnLength);
            var p = publisher.PadRight(columnLength);
            return $"| {i} | {t} | {a} | {p} | ";
        }
    }
}
