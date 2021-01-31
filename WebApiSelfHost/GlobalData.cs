using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebApiSelfHost.Models;

namespace WebApiSelfHost
{
    static class GlobalData
    {
        public static List<Person> People { get; private set; } = new List<Person>();

        public static void Load()
        {
            SetupPeople();
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
    }
}
