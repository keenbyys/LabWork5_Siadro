using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW5_Siadro
{
    public class Lion : Animal, IEatMeat
    {
        public Lion() 
        {
        }

        public Lion(string name, string species, int age)
            : base(name, species, age)
        {
            Name = name;
            Species = "Carnivore";
            Age = age;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(" Name: {0}\n" +
                " Species: {1}\n" +
                " Age: {2}\n", Name, Species, Age);
        }

        public void EatMeat()
        {
            Console.WriteLine(" The lion eats meat.");
        }
    }
}
