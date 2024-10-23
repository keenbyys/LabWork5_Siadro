using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LW5_Siadro
{
    public class Elephant : Animal, IEatPlants
    {
        public Elephant()
            : base()
        {
        }

        public Elephant(string name, string species, int age)
            : base(name, species, age)
        {
            Name = name;
            Species = "Herbivore";
            Age = age;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\n Name: {0}" +
                "\n Species: {1}" +
                "\n Age: {2}", Name, Species, Age);
        }

        public void EatPlants()
        {
            Console.WriteLine(" An elephant eats plants.");
        }
    }
}
