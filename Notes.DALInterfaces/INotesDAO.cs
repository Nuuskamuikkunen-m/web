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
        //Task<bool> AddNote(Note note);
        Task<bool> AddNote(int idUser, string notename, string notetext, DateTime creationDate);
        Task<bool> RemoveNote(int id);
        Task<bool> EditNote(int id, string NewText);
        Task<Note> GetNote(int id);
        //IEnumerable<Note> GetNotes(bool orderById);
        //IEnumerable<Note> GetUsersNotes(int idUser);
        Task<List<Note>> GetUsersNotes(int idUser);
        Task<bool> AddUser(string name, DateTime reg, string login,  string password, string phoneNumber);
        Task<bool> CheckAccount(string login, string password);
        Task<bool> EditAccount(Account account);
        Task<bool> EditUser(User user);
        Task<Account> GetAccount(string login);

        Task<Account> GetAccount(int id);
        Task<User> GetUser(int id);

    }
}
