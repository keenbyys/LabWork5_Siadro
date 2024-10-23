using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Serialization;

namespace LW5_Siadro
{
    public class AnimalSystem
    {
        private List<Animal> animals = new List<Animal>();

        public void AddElephant(Elephant elephant)
        {
            animals.Add(elephant);
        }

        public void AddLion(Lion lion)
        {
            animals.Add(lion);
        }

        public void PrintAllAnimals()
        {
            for (int i = 0; i < animals.Count; i++)
                Console.WriteLine(" {0}. {1}", i, animals[i].Name);
        }

        public void PrintAnimalDetails(int listNumber) 
        {
            switch (listNumber)
            {
                case int number when (number >= 0 && number < animals.Count):
                    animals[listNumber].DisplayInfo();
                    break;

                default:
                    Console.WriteLine(" Incorrect data! Try again!");
                    break;
            }
        }

        public void FeedAnimal(int selectedAnimal)
        {
            Animal animal = animals[selectedAnimal];
            
            if (animal is IEatMeat carnivore)
            {
                carnivore.EatMeat();
            }
            else if (animal is IEatPlants herbivore)
            {
                herbivore.EatPlants();
            }
        }

        // Зберігати інформацію про тварин у файл у форматі XML.
        public void SaveFileXML()
        {
            string fileName = "C:\\Users\\sjdro\\source\\repos\\LabWork5_Siadro\\LW5_Siadro\\LW5_Siadro\\animals.xml";
            try 
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Animal>), new Type[] { typeof(Elephant), typeof(Lion) });

                using (FileStream streamWriter = new FileStream(fileName, FileMode.Create))
                {
                    serializer.Serialize(streamWriter, animals);
                }
                Console.WriteLine("\n  Data successfully saved: {0}", fileName);
            }
            catch
            {
                Console.WriteLine("\n The data has not been saved");
            }
        }

        // Завантажувати інформацію про тварин із файлу у форматі XML.
        public void LoadFileXML()
        {
            string fileName = "C:\\Users\\sjdro\\source\\repos\\LabWork5_Siadro\\LW5_Siadro\\LW5_Siadro\\animals.xml";
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Animal>),
                new Type[] { typeof(Lion), typeof(Elephant) });

                using (StreamReader streamReader = new StreamReader(@fileName))
                {
                    animals = (List<Animal>)serializer.Deserialize(streamReader);
                }
                Console.WriteLine("\n Data successfully loaded: {0}", fileName);
            }
            catch
            {
                Console.WriteLine("\n No data has been loaded.");
            }
        }

        public void PrintLoadData()
        {
            switch (animals.Count)
            {
                case 0:
                    Console.WriteLine("\n There's no data.");
                    break;

                default:
                    Console.WriteLine(" Loaded data: ");
                    for (int i = 0; i < animals.Count; i++)
                        Console.WriteLine(" {0}. {1}", i, animals[i].Name);
                    break;
            }
        }
    }
}
