﻿using System;
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

        public void AddElephant(Elephant elephant) // Додавати нових тварин до зоопарку, вказуючи вид тварини
        {
            animals.Add(elephant);
        }

        public void AddLion(Lion lion) // Додавати нових тварин до зоопарку, вказуючи вид тварини
        {
            animals.Add(lion);
        }

        public void PrintAllAnimals() // Виводити список усіх тварин із нумерацією.
        {
            switch (animals.Count)
            {
                case 0:
                    Console.WriteLine(" ви ще не додали тварин до зоопарку! Спробуйте додати тварину до зоопарку через розділ додати тварину.");
                    break;

                default:
                    for (int i = 0; i < animals.Count; i++)
                        Console.WriteLine(" {0}. {1}", i, animals[i].Name);
                    break;
            }
        }

        public void PrintAnimalDetails(int listNumber) // Виводити детальну інформацію про конкретну тварину за номером
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
                if (!File.Exists(fileName))
                {
                    using(FileStream ass = File.Create(fileName))
                    {
                    }

                    Console.WriteLine(" tipa sosdali");
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<Animal>), new Type[] { typeof(Elephant), typeof(Lion) });

                using (FileStream streamWriter = new FileStream(fileName, FileMode.Create))
                {
                    serializer.Serialize(streamWriter, animals);
                }
                Console.WriteLine(" Данні успішно збережені: {0}", fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
                Console.WriteLine(" Данні успішно завантажені: {0}", fileName);
            }
            catch
            {
                Console.WriteLine(" Помилка.");
            }
        }

        public void PrintLoadData()
        {
            switch (animals.Count)
            {
                case 0:
                    Console.WriteLine(" Нічого немає, сорри");
                    break;

                default:
                    Console.WriteLine(" завантажені данні");
                    for (int i = 0; i < animals.Count; i++)
                        Console.WriteLine(" {0}. {1}", i, animals[i].Name);
                    break;
            }
        }
    }
}