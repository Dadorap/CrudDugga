using CrudDugga.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDugga.Crud
{
    public class Create
    {

        private readonly IDisplay _displayName;
        private readonly IMenu _menu;

        public Create(IDisplay _display, IMenu _displayMenu)
        {
            _displayName = _display;
            _menu = _displayMenu;
        }

        public void CreateUser()
        {
            Console.Clear();
            string filePath = "../../../Files/UserInfo.csv";

            _displayName.DisplayName();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Type 'cancel' to return to the menu");
            Console.Write("Enter new Name: ");
            var nameInput = Console.ReadLine().ToUpper();

            if (nameInput == "CANCEL")
            {
                _menu.DisplayMenu();
            }

            using (StreamWriter sw = new StreamWriter(filePath, true)) // 'true' to append to the file
            {
                sw.WriteLine(nameInput);
            }
            Console.Clear();
            Console.WriteLine($"{nameInput} added to the list.");
            Console.Write("press any key to return to menu...");
            Console.ReadKey();
            _menu.DisplayMenu();

        }
    }
}
