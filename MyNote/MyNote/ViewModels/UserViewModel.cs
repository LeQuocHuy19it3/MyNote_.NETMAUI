using MyNote.IService;
using MyNote.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyNote.Mobile.LoginRegister;

namespace MyNote.ViewModels
{
    public class UserViewModel : IUserService
    {
        private string baseUrl = "http://192.168.1.14:1011/api/User/";
        public int userId = 0;
        public async Task<UserModel> Login(string username, string password)
        {
            var userInfor = new List<UserModel>();
            //
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + username + "/" + password);
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode) {
                string content = responseMessage.Content.ReadAsStringAsync().Result;
                userInfor = JsonConvert.DeserializeObject<List<UserModel>>(content);
                return await Task.FromResult(userInfor.FirstOrDefault());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Register(UserModel user)
        {
            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8,"application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "add");
            HttpResponseMessage responseMessage = await client.PostAsync("", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            } else
            {
                return false;
            }
        }
        
    }
}
