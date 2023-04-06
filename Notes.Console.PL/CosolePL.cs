using Notes.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Console.PL
{
    public class CosolePL
    {
        static void Main(string[] args)
        {
            var bll = DependencyResolver.Instance.NotesLogic;
            //предоложим я тут наделала дел
        }
    }
}
