using CrudDugga.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDugga.DisplayFolder
{
    internal class DisplayNameRight : IDisplay
    {
        public void DisplayName()
        {
            string filePath = "../../../Files/UserInfo.txt";
            List<string> list = new List<string>();
            if (File.Exists(filePath))
            {


                Console.SetCursorPosition(38, 0);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Names List");

                foreach (string item in File.ReadAllLines(filePath))
                {
                    list.Add(item);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    Console.SetCursorPosition(38, i + 1);
                    Console.WriteLine(list[i]);
                }

                Console.ResetColor();
            }
        }
    }
}
