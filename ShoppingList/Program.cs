using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"C:\Users\...\samples";
            Console.WriteLine("Enter directory name:");
            string newDirectory = Console.ReadLine();
            Console.WriteLine("Enter file name:");
            string fileName = Console.ReadLine();


            if (Directory.Exists($"{rootDirectory}\\{newDirectory}") && File.Exists($"{rootDirectory}\\{newDirectory}\\{fileName}"))
            {
                Console.WriteLine($"Directory and file exist.");
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}\\{newDirectory}");
                File.Create($"{rootDirectory}\\{newDirectory}\\{fileName}").Close();
            }

            string[] arrayFromFile = File.ReadAllLines($"{rootDirectory}\\{newDirectory}\\{fileName}");
            List<string> myShoppingList = arrayFromFile.ToList<string>();

            ReadShoppingList(myShoppingList);

            bool loopActive = true;

            while (loopActive)
            {
                Console.WriteLine("Enter item name(Type exit for Exit and Save):");
                string userItem = Console.ReadLine().ToLower();

                if (userItem != "exit")
                {
                    myShoppingList.Add(userItem);
                }
                else
                {
                    loopActive = false;
                }
            }

            Console.Clear();
            ReadShoppingList(myShoppingList);

            File.WriteAllLines($"{rootDirectory}\\{newDirectory}\\{fileName}", myShoppingList);
        }
        public static void ReadShoppingList(List<string> userInput)
        {
            Console.WriteLine("Your current list:");
            foreach (string item in userInput)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
