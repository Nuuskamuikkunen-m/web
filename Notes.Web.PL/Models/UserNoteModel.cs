using Notes.Common.Entities;
using System.Threading.Tasks;


namespace Notes.Web.PL.Models
{
    public class UserNoteModel
    {
        public int ID { get;  set; }
        public string Text { get; set; }
        public string Name { get;set; }
        public DateTime CreationDate { get; set; }

        public static UserNoteModel NoteFromEntity(Note note)
        {
            return new UserNoteModel()
            {
                ID = note.ID,
                Text = note.Text,
                Name = note.Name,
                CreationDate = note.CreationDate
            };

        }
    }
}
