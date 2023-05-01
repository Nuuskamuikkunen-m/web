using Microsoft.AspNetCore.Mvc;
using Notes.Web.PL.Models;
using System.Diagnostics;
using Notes.BLL.BLL;
using Notes.DAL.DAL;
using Notes.DALInterfaces;
using Notes.BLLIntefaces;
using Notes.Common.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Notes.Web.PL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private INotesLogic _notesLogic;

        public HomeController(ILogger<HomeController> logger, INotesLogic notesLogic)
        {
            _logger = logger;
            _notesLogic = notesLogic;
        }
        public async Task<IActionResult> GetUsersNote()
        {
            string login = User.Identity.Name;
            //var login = "myhardlogin";
            var user = await _notesLogic.GetAccount(login);
            var usersTask = await _notesLogic.GetUsersNotes(user.Id);
            if (usersTask.Count > 0)
            {
                var userTaskSelected = usersTask.Select(UserNoteModel.NoteFromEntity).ToList();
                return View(userTaskSelected);
            }
            ViewBag.Message = "Нет ни одной заметки!";
            return View();
        }

        public async Task<IActionResult> GetUserAccount()
        {
            string login = User.Identity.Name;
            //var login = "tihon2023";
            //var login = "myhardlogin";
            var account = await _notesLogic.GetAccount(login);
            var user = await _notesLogic.GetUser(account.Id);

            return View(SetAccountUser(account, user));
        }

        private AccountUserModel SetAccountUser(Account account, User user)
        {
            var accountUser = new AccountUserModel();
            accountUser.Id = user.ID;
            accountUser.Name = user.Name;
            accountUser.PhoneNumber = user.PhoneNumber;
            accountUser.Login = account.Login;
            accountUser.Password = account.Password;

            return accountUser;
        }

        //public IActionResult GetUsersNote(UserModel user)
        //{
        //    var id = user.Id;
        //    var usersNote = _notesLogic.GetUsersNotes(id);
        //    var userNoteSelected = usersNote.Select(UserNoteModel.NoteFromEntity);
        //    return View(userNoteSelected);
        //}

        //public IActionResult AddNote(UserModel user, UserNoteModel note)
        //{
        //    var id = user.Id;
        //    var name = note.Name;
        //    var text = note.Text;
        //    var creationDate = note.CreationDate;

        //    _notesLogic.AddNote(id, name, text, creationDate);
        //    return RedirectToAction("GetUsersNotes", "Home");
        //}

        //public IActionResult RemoveNote(UserNoteModel note)
        //{
        //    _notesLogic.RemoveNote(note.ID);
        //    return RedirectToAction("GetUsersNote", "Home");
        //}

        //// public IActionResult EditTask(UserModel user, UserNoteModel noteModel)
        ////{
        ////    var id = user.Id;
        ////    var name = noteModel.Name;
        ////    var text = noteModel.Text;
        ////    var creationDate = noteModel.CreationDate;

        ////    var note = new Note(user.Id, text, creationDate, name);
        ////    _notesLogic.EditNote(note);
        ////    return RedirectToAction("GetNote", "Home");
        ////}
        //public IActionResult GetNote(UserNoteModel noteModel)
        //{
        //    var note = _notesLogic.GetNote(noteModel.ID);
        //    var taskFromEntity = UserNoteModel.NoteFromEntity(note);
        //    return View(taskFromEntity);
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}