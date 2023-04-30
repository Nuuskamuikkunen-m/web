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
        //public bool AddNote(Note note) =>
        //    _notesDAO.AddNote(note);

        //public bool AddNote(int idUser, string notename, string notetext, DateTime creationDate) =>
        //    _notesDAO.AddNote(idUser, notename, notetext, creationDate);

        //public bool RemoveNote(int id) => _notesDAO.RemoveNote(id);

        //public void RemoveNote(Note note) => RemoveNote(note.ID);

        //public bool EditNote(int id, string NewText) => _notesDAO.EditNote(id, NewText);
        //public bool AddUser(string name, DateTime reg, string login, string password, string phoneNumber) => _notesDAO.AddUser(name, reg, login, password, phoneNumber);
        //public bool CheckAccount(string login, string password) => _notesDAO.CheckAccount(login, password);
        //public Note GetNote(int id)=> _notesDAO.GetNote(id);
        //public IEnumerable<Note> GetUsersNotes(int idUser) => _notesDAO.GetUsersNotes(idUser);
        //public IEnumerable<Note> GetNotes(bool orderById = true) => _notesDAO.GetNotes(orderById); 


        public async Task<bool> AddNote(int idUser, string name, string text, DateTime creationDate) =>
           await _notesDAO.AddNote(idUser, name, text, creationDate);

        public async Task<bool> AddUser(string name, DateTime reg, string login, string password, string phoneNumber) =>
           await _notesDAO.AddUser(name, reg, login, password, phoneNumber);

        public async Task<bool> CheckAccount(string login, string password) =>
            await _notesDAO.CheckAccount(login, password);

        public async Task<bool> RemoveNote(int id) =>
            await _notesDAO.RemoveNote(id);

        public async Task<bool> EditAccount(Account account) =>
            await _notesDAO.EditAccount(account);

        public async Task<bool> EditNote(int taskId, string text) =>
            await _notesDAO.EditNote(taskId, text);

        public async Task<bool> EditUser(User user) =>
            await _notesDAO.EditUser(user);

        public async Task<Account> GetAccount(int id) =>
            await _notesDAO.GetAccount(id);

        public async Task<Account> GetAccount(string login) =>
            await _notesDAO.GetAccount(login);

        public async Task<Note> GetNote(int id) =>
            await _notesDAO.GetNote(id);

        public async Task<User> GetUser(int id) =>
            await _notesDAO.GetUser(id);

        public async Task<List<Note>> GetUsersNotes(int idUser) =>
            await _notesDAO.GetUsersNotes(idUser);
    }
}
