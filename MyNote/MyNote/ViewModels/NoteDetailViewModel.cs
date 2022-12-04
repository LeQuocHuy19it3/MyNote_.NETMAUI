using CommunityToolkit.Mvvm.ComponentModel;
using MyNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.ViewModels
{
    public partial class NoteDetailViewModel : ObservableObject
    {
        public NoteModel noteTest { get; set; }
        public NoteDetailViewModel()
        {
            noteTest = new NoteModel(1, "ads", "sdfdsfdsfsfsdf", "12/1/2022", 0, 1);
        }
    }
}
