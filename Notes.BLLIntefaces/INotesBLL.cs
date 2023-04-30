using Notes.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BLLIntefaces
{
    public interface INotesLogic
    {

        Task<bool> AddNote(int idUser, string name, string text, DateTime creationDate);
        

        Task<bool> AddUser(string name, DateTime reg, string login, string password, string phoneNumber);
        

        Task<bool> CheckAccount(string login, string password);

        Task<bool> RemoveNote(int id);

        Task<bool> EditAccount(Account account);

        Task<bool> EditNote(int taskId, string text);

        Task<bool> EditUser(User user);

        Task<Account> GetAccount(int id);

        Task<Account> GetAccount(string login);

        Task<Note> GetNote(int id);

        Task<User> GetUser(int id);

        Task<List<Note>> GetUsersNotes(int idUser);
    }
    //bool AddNote(Note note);
    //bool AddNote(int idUser, string notename, string notetext, DateTime creationDate);
    //bool RemoveNote(int id);

    //void RemoveNote(Note note);
    //bool AddUser(string name, DateTime reg, string login, string password, string phoneNumber);
    //bool EditNote(int id, string NewText);
    //Note GetNote(int id);
    //bool CheckAccount(string login, string password);
    //IEnumerable<Note> GetNotes(bool orderById = true);
    //IEnumerable<Note> GetUsersNotes(int idUser);
}

