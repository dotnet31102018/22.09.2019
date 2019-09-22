using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2209.Models
{
    public class Airline
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Name} {Password}";
        }
    }
}