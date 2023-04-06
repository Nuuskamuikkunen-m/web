using Notes.BLL.BLL;
using Notes.BLLIntefaces;
using Notes.DAL.DAL;
using Notes.DALInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLTONE
        private static DependencyResolver _instance;

        public static DependencyResolver Instance =>
            _instance ??= new DependencyResolver();
        #endregion

        public INotesDAO NotesDao  => new NoteSQLDAO();
        public INotesLogic NotesLogic => new NotesLogic(NotesDao);
    }
}
