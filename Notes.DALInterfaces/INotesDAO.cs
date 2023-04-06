using Notes.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DALInterfaces
{
    public interface INotesDAO
    {
        void AddNote(Note note);
        void RemoveNote(int id);
        void EditNote(int id, string NewText);

        Note GetNote(int id);
        IEnumerable<Note> GetNotes(bool orderById);
    }
}
