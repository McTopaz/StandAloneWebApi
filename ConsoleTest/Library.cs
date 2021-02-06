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
        const string ExitChoice = "0";
        const int LowestChoice = 1;

        public async static Task Run()
        {
            while (true)
            {
                Welcome();
                var books = await AvailableBooks();
                var input = HandleInput(books.Count());
                ActOnInput(input, books.Select(b => b.Id));
            }
        }

        static void Welcome()
        {
            Console.WriteLine("");
            Console.WriteLine(" === Welcome to the library ==============================================================");
            Console.WriteLine("");
        }

        static async Task<IEnumerable<IBook>> AvailableBooks()
        {
            Console.WriteLine("");
            Console.WriteLine("Available books:");
            Console.WriteLine("");

            var books = await GetBooks();
            DisplayBooks(books);
            return books;
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
                Console.WriteLine(BookLine(i + 1, book));
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

        static string BookLine(int index, IBook book, int columnLength = 25)
        {
            var i = index.ToString().PadLeft(2);
            var t = book.Title.PadRight(columnLength);
            var a = book.Author.PadRight(columnLength);
            var p = book.Publisher.PadRight(columnLength);
            var g = book.Id.ToString().Substring(0, 6);
            return $"| {i} | {t} | {a} | {p} | {g}";
        }

        static string HandleInput(int numberOfBooks)
        {
            while (true)
            {
                var input = TakeInput();
                var valid = IsValidInput(input, LowestChoice, numberOfBooks);

                if (valid) return input;
            }
        }

        static string TakeInput()
        {
            Console.WriteLine();
            Console.WriteLine("Select book by index");
            Console.WriteLine($"Type '{ExitChoice}' to exit the application");
            Console.WriteLine();
            Console.Write("Enter choice: ");
            return Console.ReadLine();
        }

        static bool IsValidInput(string input, int min, int max)
        {
            if (input == ExitChoice) return true;
            
            if (int.TryParse(input, out int index) && index >= min && index <= max) return true;

            return false;
        }

        static void ActOnInput(string input, IEnumerable<Guid> ids)
        {
            CheckToTerminate(input);
            ReadBook(input, ids);
        }

        static void CheckToTerminate(string input)
        {
            if (input == ExitChoice)
            {
                Console.WriteLine();
                Console.WriteLine("Termintaing application");
                Console.WriteLine();
                Environment.Exit(0);
            }
        }

        static void ReadBook(string input, IEnumerable<Guid> ids)
        {
            var index = int.Parse(input) - 1;
            var id = ids.ElementAt(index);
            ReadChapters(id);
        }

        static void ReadChapters(Guid id)
        {
            while (true)
            {
                var chapter = GetChapter(id);

            }
        }

        static async Task<IEnumerable<IChapter>> GetChapter(Guid id)
        {
            var url = $"http://localhost:9000/api/book/{id}";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Chapter>>(json);
        }
    }
}
