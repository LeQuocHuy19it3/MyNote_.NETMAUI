using MyNote.IService;
using MyNote.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.ViewModels
{
    public class NoteViewModel : INoteService
    {
        #region Properities
        public ObservableCollection<NoteModel> noteList { get; set; } = new ObservableCollection<NoteModel>();
        public NoteModel noteTest;
        #endregion
        public NoteViewModel() { AddNoteListAsync();
            noteTest = new NoteModel(1, "ads", "sdfdsfdsfsfsdf", "12/1/2022", 0, 1);
        }
        private string baseUrl = "http://192.168.1.14:1011/api/Notes/";
        public NoteModel NoteTest
        {
            get => noteTest;

        }
        private void AddNoteListAsync()
        {
            noteList.Clear();
            
            noteList.Add(new NoteModel(1, "ads", "sdfdsfdsfsfsdf", "12/1/2022",0,1));
            noteList.Add(new NoteModel(2, "Java OOP Tutorial", "sdfdsfdsfsfsdfsvdscbsc" +
                "sdfdsnfnsdfnkjsdkjdsjfkdsjhs4rfsdnckdcmssjhfjhdhfgsdjfjshfdsnncjsdkhgjjdskjvdskfds" +
                "sdhfjdshkjsjfhdgjvfnxzjknjksdfisjfkdsjfksdjgijdkjskdjfskjfklsdjfkldsjf", "12/1/2022", 1, 1));
            noteList.Add(new NoteModel(3, "C#", "sdfdsfdsfsfsdf", "12/1/2022", 1, 1));
            noteList.Add(new NoteModel(4, "C", "sdfdsfdsfsfsdf", "12/1/2022", 1, 1));
            noteList.Add(new NoteModel(5, "C++", "sdfdsfdsfsfsdf", "12/1/2022", 1, 1));
            noteList.Add(new NoteModel(6, "Python", "csacsajfhkjsafkjajdkjadkjasd" +
                "sadshfsdhfksjhjsk", "12/1/2022", 1, 1));
        }
        public async Task<List<NoteModel>> GetAllNotes()
        {
            var note = new List<NoteModel>();
            //
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.14:1011/api/Notes");
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                note = await responseMessage.Content.ReadFromJsonAsync<List<NoteModel>>();

            }
            return await Task.FromResult(note);
        }

        public async Task<List<NoteModel>> GetNotesByNotebookId(int notebookId)
        {
            var note = new List<NoteModel>();
            //
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl+notebookId);
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                note = await responseMessage.Content.ReadFromJsonAsync<List<NoteModel>>();

            }
            return await Task.FromResult(note);
        }
    }
}
