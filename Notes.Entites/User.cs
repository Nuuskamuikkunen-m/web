﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Notes.Common.Entities
{
    public class User
    {
        public User(int id, string name, DateTime regDate, DateTime dateOfBirth, string number)
        {
            ID = id;
            Name = name;
            RegDate = regDate;
            DateOfBirth = dateOfBirth;
            PhoneNumber = number;
        }

        public int ID { get; private set; }

        public string Name { get; private set; }

        public DateTime RegDate { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public string PhoneNumber { get; private set; }

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
