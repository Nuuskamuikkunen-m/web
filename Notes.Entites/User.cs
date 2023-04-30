using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Notes.Common.Entities
{
    public class User
    {
        public User(int id, string name, DateTime regDate, string number)
        {
            ID = id;
            Name = name;
            RegDate = regDate;
            PhoneNumber = number;
        }

        public int ID { get; }
        public string Name { get; private set; }
        public DateTime RegDate { get; }
        public string PhoneNumber { get; private set; }

        public void EditName(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name", "Name cannot be null!");
            Name = name;
        }

        //public override string ToString() =>
        //     JsonConvert.SerializeObject(this);

        public override string? ToString()
        {
            var res = new StringBuilder();

            res.Append("Name: ").Append(Name).Append("\n")
                .Append("PhoneNumber: ").Append(PhoneNumber).Append("\n")
                .Append("RegDate: ").Append(RegDate);

            return res.ToString();
        }
    }
}
