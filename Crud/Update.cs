using CrudDugga.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Channels;

namespace CrudDugga.Crud
{
    public class Update
    {
        private readonly IDisplay _displayName;
        private readonly IMenu _menu;

        public Update(IDisplay display, IMenu menu)
        {
            _displayName = display;
            _menu = menu;
        }

        public void EditUser()
        {
            Console.Clear();
            string filePath = "../../../Files/UserInfo.csv";

            _displayName.DisplayName();
            Console.SetCursorPosition(0, 0);

            bool state = true;

            while (state)
            {
                Console.WriteLine("Type 'cancel' to return to the menu");
                Console.Write("Enter name to change: ");
                var nameInput = Console.ReadLine().ToUpper();

                if (nameInput == "CANCEL")
                {
                    _menu.DisplayMenu();
                }

                var lines = File.ReadAllLines(filePath);
                var nameList = new List<string>();

                bool found = false;

                foreach (string line in lines)
                {
                    if (line.ToUpper() == nameInput)
                    {
                        found = true;
                        Console.WriteLine($"Name to change: {line}");
                        Console.Write("Enter new name: ");
                        var newName = Console.ReadLine().ToUpper();
                        nameList.Add(newName);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{nameInput} updated successfully to {newName}.");
                        Console.ResetColor();
                    }
                    else
                    {
                        nameList.Add(line);
                    }
                }

                if (found)
                {
                    File.WriteAllLines(filePath, nameList);

                    Console.Write("Press any key to return to the menu...");
                    Console.ReadKey();
                    _menu.DisplayMenu();
                    state = false;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }
        }
    }
}
