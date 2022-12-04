using MyNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.IService
{
    public interface IUserService
    {
        Task<UserModel> Login(string username, string password);
        Task<bool> Register(UserModel user);
    }
}
