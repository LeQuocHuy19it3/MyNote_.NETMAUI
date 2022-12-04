
using MyNote.IService;
using MyNote.Mobile.LoginRegister;
using MyNote.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.ViewModels
{
    public class NotebookViewModel : INotebookService
    {
        private readonly IUserService _userService = new UserViewModel();
        #region Properities
        public ObservableCollection<NotebookModel> notebookList { get; set; } = new ObservableCollection<NotebookModel>();
        #endregion
        public NotebookViewModel() { AddNotebookListAsync(); }
        private string baseUrl = "http://192.168.1.14:1011/api/Notebook/";
        private async void AddNotebookListAsync()
        {
           
            List<NotebookModel> notebook = await GetNotebookByUserId(41);
            foreach (NotebookModel m in notebook)
            {
                notebookList.Add(m);
            }
        }

        public async Task<List<NotebookModel>> GetNotebookByUserId(int userId)
        {
            var notebook = new List<NotebookModel>();
            //
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + userId);
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                notebook = await responseMessage.Content.ReadFromJsonAsync<List<NotebookModel>>();
                
            }
            return await Task.FromResult(notebook);
        }
    }
}
