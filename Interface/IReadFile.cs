using CrudDugga.UserFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDugga.Interface
{
    public interface IReadFile<T>
    {
        List<T> ReadUser();
    }
}
