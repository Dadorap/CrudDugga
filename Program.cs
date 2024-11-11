using Autofac;
using CrudDugga.DisplayFolder;
using CrudDugga.Service;

namespace CrudDugga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = DependencyInjection.Configure();
            var menu = container.Resolve<Menu>();
            menu.DisplayMenu();

        }
    }
}
