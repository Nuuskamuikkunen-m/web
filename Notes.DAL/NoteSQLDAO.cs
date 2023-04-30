using Notes.Common.Entities;
using Notes.DALInterfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Notes.DAL.DAL
{
    public class NoteSQLDAO : INotesDAO
    {
        //private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        //private static SqlConnection _connection = new SqlConnection(_connectionString);
        ////private static SqlConnection _connection = new SqlConnection("Data Source=DESKTOP-BBOCN3R;Initial Catalog=NotesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");


        private string _connectionString;
        private SqlConnection _connection;
        public NoteSQLDAO(string connectionString)
        {
            _connectionString = connectionString;
        }


        //public bool AddNote(Note note)
        //{
        //    //dbo.Notes_AddNote
        //    using (_connection = new SqlConnection(_connectionString))
        //    {

        //        var stProc = "dbo.Notes_AddNote";

        //        var command = new SqlCommand(stProc, _connection)
        //        {
        //            CommandType = System.Data.CommandType.StoredProcedure
        //        };
        //        command.Parameters.AddWithValue("@NameNote", note.Name);
        //        command.Parameters.AddWithValue("@TextNote", note.Text);
        //        command.Parameters.AddWithValue("@CreationDate", note.CreationDate);

        //        _connection.Open();

        //        var result = command.ExecuteNonQuery();

        //        return result > 0;
        //    }
        //}

        public async Task<bool> AddNote(int idUser, string notename, string notetext, DateTime creationDate)
        {
            using (_connection = new SqlConnection(_connectionString))
            {

                var stProc = "dbo.Notes_AddNoteUSERPROFILE";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@name", notename);
                command.Parameters.AddWithValue("@TextNote", notetext);
                command.Parameters.AddWithValue("@CreationDate", creationDate);
                command.Parameters.AddWithValue("@iduser", idUser);

                _connection.Open();


                try
                {
                    var result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            throw new InvalidOperationException(
                    string.Format("Cannot add note "));
        }



        public async Task<bool> RemoveNote(int id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "dbo.Notes_RemoveNote";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", id);

                _connection.Open();

                try
                {
                    //!!!!!
                    var result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }


                throw new InvalidOperationException(
                    string.Format("Cannot remove note by id: {0}",
                    id));
            }

        }

        public async Task<bool> EditNote(int id, string newText)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "dbo.Notes_EditNote";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@newTextNote", newText);


                _connection.Open();
                try
                {
                    // !!!
                    var result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        //public async Task<bool> EditNote(Note note)
        //{
        //    using (_connection = new SqlConnection(_connectionString))
        //    {
        //        var strProc = "dbo.Notes_EditNote";

        //        var command = new SqlCommand(strProc, _connection)
        //        {
        //            CommandType = System.Data.CommandType.StoredProcedure
        //        };

        //        command.Parameters.AddWithValue("@ID", note.ID);
        //        command.Parameters.AddWithValue("@newTextNote", note.Text);


        //        _connection.Open();
        //        try
        //        {
        //            // !!!
        //            var result = command.ExecuteNonQuery();
        //            return result > 0;
        //        }
        //        catch (SqlException ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //    }
        //}


        public async Task<Note> GetNote(int id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var stProc = "Notes_GetNoteById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Note(
                        id: (int)reader["ID"],
                        text: reader["TextNote"] as string, //!!!!
                        creationDate: (DateTime)reader["CreationDate"],
                        name: reader["NameNote"] as string);
                }

                throw new InvalidOperationException("Cannot find file with ID = " + id);

            }

        }

        //public IEnumerable<Note> GetUsersNotes(int idUser)
        //{
        //    using (_connection = new SqlConnection(_connectionString))
        //    {
        //        var strProc = "Notes_GetUserNotes";

        //        var command = new SqlCommand(strProc, _connection)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };

        //        command.Parameters.AddWithValue("@ID_User", idUser);

        //        _connection.Open();

        //        var reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            yield return new Note(
        //                id: Convert.ToInt32(reader["ID"]),
        //                name: reader["NameNote"] as string,
        //                text: reader["TextNote"] as string,
        //                creationDate: Convert.ToDateTime(reader["CreationDate"]));
        //        }
        //    }


        //}

        public async Task<List<Note>> GetUsersNotes(int idUser)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Notes_GetUserNotes";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID_User", idUser);

                _connection.Open();

                var reader = command.ExecuteReader();
                var notes = new List<Note>();


                while (reader.Read())
                {
                    notes.Add( new Note(
                        id: Convert.ToInt32(reader["ID"]),
                        name: reader["NameNote"] as string,
                        text: reader["TextNote"] as string,
                        creationDate: Convert.ToDateTime(reader["CreationDate"]))
                        );
                }
                return notes;
            }


        }

        //public IEnumerable<Note> GetNotes(bool orderById = true)
        //{
        //    //Notes_GetNotes
        //    using (_connection = new SqlConnection(_connectionString))
        //    {

        //        var stProc = "dbo.Notes_GetNotes";
        //        var command = new SqlCommand(stProc, _connection)
        //        {
        //            CommandType = System.Data.CommandType.StoredProcedure
        //        };
        //        //var command = new SqlCommand(query, _connection);

        //        _connection.Open();

        //        var reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            yield return new Note(
        //                id: (int)reader["ID"],
        //                text: reader["TextNote"] as string, //!!!!
        //                creationDate: (DateTime)reader["CreationDate"],
        //                name: reader["NameNote"] as string);
        //        }

        //    }



        //}

        public async Task<bool> AddUser(string name, DateTime reg, string login, string password, string phoneNumber)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "dbo.Notes_AddUser";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@NameUs", name);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@regdate", reg);
                command.Parameters.AddWithValue("@PhoneNumber", Convert.ToDecimal(phoneNumber));

                _connection.Open();

                try
                {
                    var result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }

                throw new InvalidOperationException(
                    string.Format("Cannot add user with parameters: {0}, {1}, {2}",
                    name, login, phoneNumber));
            }
        }
        public async Task<bool> CheckAccount(string login, string password)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Notes_CheckAccount";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Login", login);

                _connection.Open();

                var result = command.ExecuteScalar();

                return result.Equals(1);

                throw new InvalidOperationException(
                    string.Format("Cannot check user with parameters: {0}, {1}",
                    login, password));
            }
        }

        public async Task<bool> EditAccount(Account account)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProcUser = "Notes_EditAccount";

                var command = new SqlCommand(strProcUser, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", account.Id);
                command.Parameters.AddWithValue("@Login", account.Login);
                command.Parameters.AddWithValue("@Password", account.Password);

                _connection.Open();
                try
                {
                    var result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public async Task<bool> EditUser(User user)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProcUser = "Notes_EditUser";

                var command = new SqlCommand(strProcUser, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };


                try
                {
                    command.Parameters.AddWithValue("@ID_User", user.ID);
                    command.Parameters.AddWithValue("@NameUser", user.Name);
                    command.Parameters.AddWithValue("@PhoneNumber", Convert.ToDecimal(user.PhoneNumber));

                    _connection.Open();

                    var result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public async Task<Account> GetAccount(int id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Notes_GetAccountById";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID_User", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Account(
                        id: Convert.ToInt32(reader["ID_Account"]),
                        login: reader["LoginUser"] as string,
                        password: reader["Pass"] as string);
                }

                throw new InvalidOperationException("Cannot find Account whith ID = " + id);
            }
        }
        public async Task<Account> GetAccount(string login)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Notes_GetAccountByLogin";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Login", login);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Account(
                        id: Convert.ToInt32(reader["ID_Account"]),
                        login: reader["LoginUser"] as string,
                        password: reader["Pass"] as string);
                }

                throw new InvalidOperationException("Cannot find Account whith login = " + login);
            }
        }
        public async Task<User> GetUser(int id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Notes_GetUserById";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID_User", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User(
                        id: Convert.ToInt32(reader["ID_User"]),
                        name: reader["NameUser"] as string,
                        regDate: Convert.ToDateTime(reader["RegistrationDate"]),
                        number: (reader["PhoneNumber"]).ToString());
                }

                throw new InvalidOperationException("Cannot find User whith ID = " + id);
            }
        }

    }
}
