using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSelfHost.Models
{
    public class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
        }
    }
}
