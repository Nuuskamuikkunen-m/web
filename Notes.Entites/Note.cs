using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Common.Entities
{
    public class Note
    {
        
        public Note(int id, string text,  DateTime creationDate, string name)
        {
            ID = id;
            Text = text;
            CreationDate = creationDate;
            Name = name;
        }

        public Note(int id, string text, string name)
        {
            ID = id;
            Text = text;
            CreationDate = DateTime.Now;
            Name = name;
        }
        public Note(string text, string name)
        {
            ID = -1;
            Text = text;
            CreationDate = DateTime.Now;
            Name = name;
        }


        public int ID { get; }
        public string Name { get; private set; }
        public string Text { get; private set; }
        public DateTime CreationDate { get; }

        public void EditName(string newname)
        {
            if (newname == null)
                throw new ArgumentNullException("name", "Name cannot be null!");
            Name = newname;
        }

        public void EditText(string newtext)
        {
            if (newtext == null)
                throw new ArgumentNullException("text", "text cannot be null!why do you need a blank note????");
            Text = newtext;
        }

        //public override string ToString() =>
        //     JsonConvert.SerializeObject(this);

        public override string? ToString()
        {
            var res = new StringBuilder();

            res.Append("Name: ").Append(Name).Append("\n")
                .Append("Note text: ").Append(Text).Append("\n")
                .Append("Created date: ").Append(CreationDate).Append("\n");

            return res.ToString();
        }
    }
}
