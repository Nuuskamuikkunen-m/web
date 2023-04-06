using Notes.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.DAL.DAL;
using Notes.DALInterfaces;
using Notes.BLLIntefaces;

namespace Notes.BLL.BLL
{
    public class NotesLogic : INotesLogic
    {
        private INotesDAO _notesDAO;
        public NotesLogic(INotesDAO notesDAO) 
        { 
            _notesDAO = notesDAO;
        }
        public void AddNote(Note note) =>
            _notesDAO.AddNote(note);

        public void RemoveNote(int id)
        {

        }

        public void RemoveNote(Note note) => RemoveNote(note.ID);

        public void EditNote(int id, string NewText)
        {

        }

        public Note GetNote(int id)=> _notesDAO.GetNote(id);
        public IEnumerable<Note> GetNotes(bool orderById = true) => _notesDAO.GetNotes(orderById); 
    }
}
