namespace ORCLAPI.Models
{
    public class Users
    {
        private int userid;
        private string name;
        private string password;

        public int Userid { get => userid; set => userid = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }

        public Users()
        {
        }

        public Users(int userid, string name, string password)
        {
            Userid = userid;
            Name = name;
            Password = password;
        }
        public Users(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
