using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Models
{
    public class NoteModel
    {
        public int noteId { get; set; }
        public string noteName { get; set; }
        public string noteDetail { get; set; }
        public string nateCreate { get; set; }
        public int isFavorite { get; set; }
        public int notebookId { get; set;}

        public NoteModel(int noteId, string noteName, string noteDetail, string nateCreate, int isFavorite, int notebookId)
        {
            this.noteId = noteId;
            this.noteName = noteName;
            this.noteDetail = noteDetail;
            this.nateCreate = nateCreate;
            this.isFavorite = isFavorite;
            this.notebookId = notebookId;
        }
    }
}
