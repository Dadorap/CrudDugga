using CrudDugga.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDugga.Crud
{
    public class Read
    {
        private readonly IReadFile<UserFolder.User> _read;
        private readonly IMenu _menu;

        public Read(IReadFile<UserFolder.User> _readFile, IMenu _displayMenu)
        {
            _read = _readFile;
            _menu = _displayMenu;
        }
        public void Get()
        {
            Console.Clear();
            var userFileGetter = _read;
            var listuser = userFileGetter.ReadUser();
            var i = 0;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("List of Names");
            foreach (var item in listuser)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    i++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    i++;
                }
                Console.WriteLine(item.Name);
                Console.ResetColor();
            }
            Console.Write("press any key to return to menu...");
            Console.ReadKey();
            _menu.DisplayMenu();



        }
    }
}
