using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Models
{
    public class UserModel
    {
        public int userid { get; set; }
        public string name { get; set; }
        public string password { get; set; }

        public UserModel(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

      
    }
}
