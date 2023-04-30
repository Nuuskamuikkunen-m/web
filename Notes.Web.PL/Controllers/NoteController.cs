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
    public class NoteController : Controller
    {
        private readonly ILogger<NoteController> _logger;
        private INotesLogic _notesLogic;

        public NoteController(ILogger<NoteController> logger, INotesLogic notesLogic)
        {
            _logger = logger;
            _notesLogic = notesLogic;
        }
        public async Task<IActionResult> AddNote(UserNoteModel note)
        {

            if (ModelState.IsValid)
            {
                string login = User.Identity.Name;
                var user = await _notesLogic.GetAccount(login);
                var name = note.Name;
                var text = note.Text;
                var creationDate = DateTime.Now;


                await _notesLogic.AddNote(user.Id, name, text, creationDate);
                return RedirectToAction("GetUsersNote", "Home");
            }

            return View(note);
        }

        public async Task<IActionResult> RemoveNote(int id)
        {
            await _notesLogic.RemoveNote(id);
            return RedirectToAction("GetUsersNote", "Home");
        }

        public async Task<IActionResult> EditNote(int id, UserNoteModel noteModel)
        {
            if (ModelState.IsValid)
            {
                var name =noteModel.Name;
                var text =noteModel.Text;
                var creationDate = DateTime.Now;
                //!!!!!!!ПОМЕНЯТЬ КОРОЧЕ НА 4 АРГУМЕНТА МЕТОД EditNote ВЕЗДЕ
                //!!!!!!!!!!!!!!!!!!
                //!!!!!!!!!!1
                await _notesLogic.EditNote(id, text);
                return RedirectToAction("GetNote", "Home");
            }
            return View(noteModel);
        }

        public async Task<IActionResult> GetNote(int id)
        {
            //var note = await _notesLogic.GetNote(id);
            var note = await _notesLogic.GetNote(4);
            var noteModel = UserNoteModel.NoteFromEntity(note);
            return View(noteModel);
        }
    }
}
