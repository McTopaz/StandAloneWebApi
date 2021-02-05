using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebApiSelfHost.Models;
using Entities.Models.Library;
using Entities.Factories;

namespace WebApiSelfHost
{
    static class GlobalData
    {
        public static List<Person> People { get; } = new List<Person>();
        public static Library Library { get; } = new Library();

        public static void Load()
        {
            SetupPeople();
            SetupLibrary();
        }

        static void SetupPeople()
        {
            var p1 = new Person
            {
                Name = "James",
                Age = 30
            };

            var p2 = new Person()
            {
                Name = "Rick",
                Age = 29
            };

            People.Add(p1);
            People.Add(p2);
        }

        static void SetupLibrary()
        {
            var b1 = BookFactory.Create("Book 1", "Foo", "Bar", (4, 3), (5, 3));
            var b2 = BookFactory.Create("Book 2", "Baz", "Qaz", (4, 4), (5, 5), (5, 6));
            Library.Books.Add(b1);
            Library.Books.Add(b2);
        }
    }
}

