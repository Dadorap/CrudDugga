using Autofac;
using CrudDugga.Crud;
using CrudDugga.Interface;
using CrudDugga.Service;
using CrudDugga.UserFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDugga.DisplayFolder
{
    public class Menu : IMenu
    {
        public void DisplayMenu()
        {
            int currentSelect = 0;
            List<string> menu = new List<string>() { "Create", "Read", "Update", "Delete", "Exit" };
            var container = DependencyInjection.Configure();
            var fileReader = container.Resolve<UserFileReader>();
            var create = container.Resolve<Create>();
            var read = container.Resolve<Read>();
            var update = container.Resolve<Update>();
            var delete = container.Resolve<Delete>();


            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Choose an option and press Enter:\n");
                Console.ResetColor();
                for (int i = 0; i < menu.Count; i++)
                {
                    if (i == currentSelect)
                    {
                        if (menu[i].ToLower() == "exit")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine($"-> {menu[i]}");
                    }
                    else
                    {
                        Console.WriteLine($">>{menu[i]}<<");
                    }
                    Console.ResetColor();
                }

                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    currentSelect = currentSelect > 0 ? currentSelect - 1 : menu.Count - 1;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    currentSelect = currentSelect < menu.Count - 1 ? currentSelect + 1 : 0;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (currentSelect)
                    {
                        case 0:
                            create.CreateUser();
                            return;
                        case 1:
                            read.Get();
                            return;
                        case 2:
                            update.EditUser();
                            return;
                        case 3:
                            delete.Remove();
                            return;
                        case 4:
                            Environment.Exit(0);
                            break;

                    }
                }
            }
        }
    }
}
