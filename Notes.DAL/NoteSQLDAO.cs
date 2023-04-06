using Notes.Common.Entities;
using Notes.DALInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL.DAL
{
    public class NoteSQLDAO : INotesDAO
    {
        
        public void AddNote(Note note)
        {
            //TODO: add note to my SQL Database
        }

        public void RemoveNote(int id)
        {
            //
        }

        public void EditNote(int id, string newText)
        {
            //
        }


        public Note GetNote(int id)
        {
            //return new Note( ... )
            throw new InvalidOperationException("lox ");
        }
        public IEnumerable<Note> GetNotes(bool orderById = true)
        {
            //yield return new ShFile( ... )

            throw new InvalidOperationException("lox ");
        }
    }
}
