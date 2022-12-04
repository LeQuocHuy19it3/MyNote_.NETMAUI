namespace ORCLAPI.Models
{
    public class Notes
    {
        private int NoteId;
        private string NoteName;
        private string NoteDetail;
        private string dateCreate;
        private int isFavorite;
        private int notebookId;

        public Notes()
        {
        }

        public int NoteId1 { get => NoteId; set => NoteId = value; }
        public string NoteName1 { get => NoteName; set => NoteName = value; }
        public string NoteDetail1 { get => NoteDetail; set => NoteDetail = value; }
        public string DateCreate { get => dateCreate; set => dateCreate = value; }
        public int IsFavorite { get => isFavorite; set => isFavorite = value; }
        public int NotebookId { get => notebookId; set => notebookId = value; }


        public Notes(int noteId1, string noteName1, string noteDetail1, string dateCreate, int isFavorite, int notebookId)
        {
            NoteId1 = noteId1;
            NoteName1 = noteName1;
            NoteDetail1 = noteDetail1;
            DateCreate = dateCreate;
            IsFavorite = isFavorite;
            NotebookId = notebookId;
        }
    }
}
