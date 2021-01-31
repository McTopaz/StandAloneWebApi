using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = nameof(ConsoleTest);

            Console.WriteLine("Press any key to read from WebApi");
            Console.ReadLine();

            TestValues();   // Works :)
            TestPeople();   // Fails :(

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        /// <summary>
        /// Read GET from the Valuescontroller.
        /// </summary>
        static void TestValues()
        {
            var url = "http://localhost:9000/api/values";
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            Console.WriteLine(response);
            Console.WriteLine("");
            Console.WriteLine($"GET from {url}");
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            Console.WriteLine("");
            Console.WriteLine("");
        }

        /// <summary>
        /// Read GET from the PeopleController.
        /// </summary>
        static void TestPeople()
        {
            var url = "http://localhost:9000/api/people";
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            Console.WriteLine(response);
            Console.WriteLine("");
            Console.WriteLine($"GET from {url}");
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
