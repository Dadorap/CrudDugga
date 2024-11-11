using CrudDugga.Interface;
using System;
using System.Collections.Generic;
using System.IO;

namespace CrudDugga.Crud
{
    public class Delete
    {
        private readonly IDisplay _displayName;
        private readonly IMenu _menu;

        public Delete(IDisplay display, IMenu menu)
        {
            _displayName = display;
            _menu = menu;
        }

        public void Remove()
        {
            Console.Clear();
            string filePath = "../../../Files/UserInfo.csv";

            _displayName.DisplayName();
            Console.SetCursorPosition(0, 0);

            bool state = true;

            while (state)
            {
                Console.WriteLine("Type 'cancel' to return to the menu");
                Console.Write("Enter name to remove: ");
                var nameInput = Console.ReadLine().ToUpper();

                var lines = new List<string>(File.ReadAllLines(filePath));
                var nameList = new List<string>(); 

                bool found = false;

                if(nameInput == "CANCEL")
                {
                    _menu.DisplayMenu();
                }

                foreach (var line in lines)
                {
                    if (line.ToUpper() == nameInput)
                    {
                        found = true; 
                    }
                    else
                    {
                        nameList.Add(line); 
                    }
                }

                if (found)
                {
                    File.WriteAllLines(filePath, nameList);

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{nameInput} removed successfully.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Write("Press any key to return to menu...");
                    _menu.DisplayMenu();
                    state = false; 
                }
                else
                {
                    Console.WriteLine("Name does not exist, try again.");
                }
            }
        }
    }
}
