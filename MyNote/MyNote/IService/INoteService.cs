using MyNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.IService
{
    public interface INoteService
    {
        Task<List<NoteModel>> GetAllNotes();
        Task<List<NoteModel>> GetNotesByNotebookId(int notebookId);
    }
}
