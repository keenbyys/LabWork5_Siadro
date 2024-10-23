using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LW5_Siadro
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }

        public Animal()
        {
        }

        public Animal(string name, string species, int age)
        {
            Name = name;
            Species = species;
            Age = age;
        }

        public abstract void DisplayInfo();
    }

}
