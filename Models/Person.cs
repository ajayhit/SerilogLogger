using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogLogger.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public Person(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
            Log.Debug("Created a person {@person} at {now}", this, DateTime.Now);
        }
    }
}
