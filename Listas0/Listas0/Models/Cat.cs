using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Listas0.Models
{
    public class Cat
    {
        public int Age { get; set; }
        public string name { get; set; }

        public Cat(string name)
        {
            this.name = name;
        }
        
    }
}