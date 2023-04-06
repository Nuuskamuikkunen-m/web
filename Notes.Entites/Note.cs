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
        
        public Note(int iD, string text, DateTime creationDate, string name)
        {
            ID = iD;
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

        public void EditName(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name", "Name cannot be null!");
            Name = name;
        }
        public override string ToString() =>
             JsonConvert.SerializeObject(this);
    }
}
