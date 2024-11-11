using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudDugga.Interface;

namespace CrudDugga.UserFolder
{
    public class User : IPerson
    {
        public string Name { get; set; }


        public User(string _name)
        {
            Name = _name;

        }
    }
}
