using CrudDugga.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDugga.UserFolder
{
    public class UserFileReader : IReadFile<User>
    {
        public List<User> ReadUser()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var user = new List<User>();
            string filePath = "../../../Files/UserInfo.csv";


            if (File.Exists(filePath))
            {

                foreach (string line in File.ReadLines(filePath))
                {
                    string name = line;
                    User userInfo = new User(name);
                    user.Add(userInfo);
                }
            }

            Console.ResetColor();
            return user;
        }
    }
}
