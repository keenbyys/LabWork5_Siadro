using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace LW5_Siadro
{
    class Program
    {
        private static AnimalSystem animalSystem = new AnimalSystem();

        private static Animal animal;
        private static Lion lion;
        private static Elephant elephant;

        private static string name;
        private static string species;
        private static int age;
        private static int choice;
        private static bool isInputCorrect = true;

        // Викликати методи EatMeat() або EatPlants() для відповідних тварин. вопрос будет от програмы, когда человек просмотрел
        // детально животное, не хочет ли он его покормить

        // MAIN MENU
        public static void MainMenu()
        {
            Console.WriteLine("\n Welcome! You're at the zoo, what's your next move?" +
                "\n [1] Add an animal" +
                "\n [2] Print a list of all animals" +
                "\n [3] Display detailed information about the animal" +
                "\n [4] Save animal data" +
                "\n [5] Load animal data" +
                "\n [6] Exit");

            while (isInputCorrect)
            {
                try
                {
                    Console.Write("\n Your choice (number): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            MenuCreateAnimal();
                            isInputCorrect = false;
                            break;
                        
                        case 2:
                            Console.Clear();
                            PrintAllAnimals();
                            isInputCorrect = false;
                            break;
                        
                        case 3:
                            Console.Clear();
                            PrintDetailInfoAnimal();
                            isInputCorrect = false;
                            break;
                        
                        case 4:
                            Console.Clear();
                            SaveDataAnimal();
                            isInputCorrect = false;
                            break;
                        
                        case 5:
                            Console.Clear();
                            LoadDataAnimal();
                            isInputCorrect = false;
                            break;
                        
                        case 6:
                            Console.Clear();
                            Exit();
                            isInputCorrect = false;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                                "\n Try entering it again: 1 or 2 or 3 or 4 or 5 or 6! :3");
                            MainMenu();
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n Non-numeric data were entered. " +
                        "\n Try entering numbers: 1 or 2 or 3 or 4 or 5 or 6! :3");
                    MainMenu();
                    isInputCorrect = false;
                }
            }
        }

        public static void MenuCreateAnimal()
        {
            Console.WriteLine("\n What animal would you prefer to add?" +
                "\n [1] Elephant" +
                "\n [2] Lion" +
                "\n [3] Return");

            while (isInputCorrect)
            {
                try
                {
                    Console.Write("\n Your choice (number): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            CreateObject(1);
                            isInputCorrect = false;
                            break;
                        case 2:
                            Console.Clear();
                            CreateObject(2);
                            isInputCorrect = false;
                            break;
                        case 3:
                            Console.Clear();
                            MainMenu();
                            isInputCorrect = false;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                                "\n Try entering it again: 1 or 2 or 3! :^)");
                            MenuCreateAnimal();
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n Non-numeric data were entered. " +
                        "\n Try entering numbers: 1 or 2 or 3. :^)");
                    MenuCreateAnimal();
                    isInputCorrect = false;
                }
            }
        }

        public static void CreateObject(int choiceAnimal)
        {
            switch (choiceAnimal)
            {
                case 1:
                    UserInputNameAnimal(choiceAnimal);
                    break;
                case 2:
                    UserInputNameAnimal(choiceAnimal);
                    break;
            }
        }

        public static void UserInputNameAnimal(int choiceAnimal)
        {
            while (isInputCorrect)
            {
                try
                {
                    switch (choiceAnimal)
                    {
                        case 1:
                            Console.WriteLine("\n What name do you want to give the elephant?");
                            break;

                        case 2:
                            Console.WriteLine("\n What name do you want to give the lion?");
                            break;
                    }
                    
                    Console.Write("\n Your choice: ");
                    name = Console.ReadLine();
                    ReinterpretationNameAnimal(choiceAnimal, name);
                    isInputCorrect = false;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n You have entered an empty field. Try writing something.");
                    UserInputNameAnimal(choiceAnimal);
                    isInputCorrect = false;
                }
            }
        }

        public static void ReinterpretationNameAnimal(int choiceAnimal, string name)
        {
            while (isInputCorrect)
            {
                try
                {
                    Console.WriteLine("\n Are you happy with the name you've given the animal?" +
                        "\n [1] Yes" +
                        "\n [2] Nah, I want to change the animal's name.");

                    Console.Write("\n Your choice (number): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            UserInputAgeaAnimal(choiceAnimal, name);
                            isInputCorrect = false;
                            break;

                        case 2:
                            Console.Clear();
                            UserInputNameAnimal(choiceAnimal);
                            isInputCorrect = false;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                                "\n Try entering it again: 1 or 2! :D");
                            ReinterpretationNameAnimal(choiceAnimal, name);
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n Non-numeric data were entered." +
                        "\n Try entering it again: 1 or 2! :D");
                    ReinterpretationNameAnimal(choiceAnimal, name);
                    isInputCorrect = false;
                }
            }
        }

        public static void UserInputAgeaAnimal(int choiceAnimal, string name)
        {
            while (isInputCorrect)
            {
                try
                {
                    Console.WriteLine("\n What is the age of the animal?");
                    Console.Write("\n Your choice (number): ");
                    age = Convert.ToInt32(Console.ReadLine());

                    if (age > 0 && name != "")
                    {
                        switch (choiceAnimal)
                        {
                            case 1:
                                Console.Clear();
                                species = "Herbivore";
                                elephant = new Elephant(name, species, age);
                                animalSystem.AddElephant(elephant);
                                MainMenu();
                                isInputCorrect = false;
                                break;

                            case 2:
                                Console.Clear();
                                species = "Carnivore";
                                lion = new Lion(name, species, age);
                                animalSystem.AddLion(lion);
                                MainMenu();
                                isInputCorrect = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("\n Either blank fields or an age value below zero have been entered. " +
                            "\n Try entering the data again.");
                        UserInputNameAnimal(choiceAnimal);
                        isInputCorrect = false;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n Non-numeric data were entered.");
                    UserInputAgeaAnimal(choiceAnimal, name);
                    isInputCorrect = false;
                }
            }
        }


        public static void PrintAllAnimals()
        {
            Console.Clear();
            animalSystem.PrintAllAnimals();
            MainMenu();
        }

        public static void PrintDetailInfoAnimal()
        {
            while (isInputCorrect)
            {
                try
                {
                    if (elephant != null || lion != null) 
                    {
                        animalSystem.PrintAllAnimals();

                        Console.WriteLine("\n What kind of animal do you want to choose?");

                        Console.Write("\n Your choice (number): ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        animalSystem.PrintAnimalDetails(choice);

                        EatAnimalMenu(choice);
                        isInputCorrect = false;
                    }
                    else
                    {
                        Console.Clear();
                        ReinterpretationAddAnimal();
                        isInputCorrect = false;
                    }
                       
                    
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n Incorrect values have been entered. Try again!");
                    PrintDetailInfoAnimal();
                    isInputCorrect = false;
                }
            }
        }

        public static void EatAnimalMenu(int chosenАnimal)
        {
            Console.WriteLine("\n Would you like to feed the animal?" +
                "\n [1] Yep!" +
                "\n [2] Nope, let's go back to the main menu");

            while (isInputCorrect)
            {
                try
                {
                    Console.Write("\n Your choice (number): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            animalSystem.FeedAnimal(chosenАnimal);
                            MainMenu();
                            isInputCorrect = false;
                            break;
                        case 2:
                            Console.Clear();
                            MainMenu();
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n Incorrect values have been entered. Try again!");
                    EatAnimalMenu(chosenАnimal);
                    isInputCorrect = false;
                }
            }
        }

        public static void SaveDataAnimal()
        {
            animalSystem.SaveFileXML();
            MainMenu();
        }

        public static void LoadDataAnimal()
        {
            animalSystem.LoadFileXML();
            animalSystem.PrintLoadData();
            MainMenu();
        }

        public static void ReinterpretationAddAnimal()
        {
            while (isInputCorrect)
            {
                Console.WriteLine("\n There are no animals in the zoo." +
                    "\n Would you like to add an animal to the zoo?" +
                    "\n [1] Yes" +
                    "\n [2] No, I want to go back to the main menu");

                try
                {
                    Console.Write("\n Your choice (number): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice) 
                    {
                        case 1:
                            Console.Clear();
                            MenuCreateAnimal();
                            isInputCorrect= false;
                            break;

                        case 2:
                            Console.Clear();
                            MainMenu();
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n Incorrect values have been entered. Try again!");
                    ReinterpretationAddAnimal();
                    isInputCorrect = false;
                }
            }
        }

        static void Exit()
        {
            Console.WriteLine("\n Oh, are you sure about that? (Т_Т)" +
                "\n [1] Yes" +
                "\n [2] No, can I go back in?");

            while (isInputCorrect)
            {
                try
                {
                    Console.Write("\n Your choice (number): ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n The application is now complete.\n");
                            isInputCorrect = false;
                            break;
                        case 2:
                            Console.Clear();
                            MainMenu();
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\n Incorrect values have been entered. Try again!");
                    Exit();
                    isInputCorrect = false;
                }
            }
        }

        static void Main(string[] args)
        {
            MainMenu();
        }
    }
}