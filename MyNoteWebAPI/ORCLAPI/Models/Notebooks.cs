namespace ORCLAPI.Models
{
    public class Notebooks
    {
        private int notebookId;
        private string notebookName;
        private string dateCreate;
        private int UserId;

        public int NotebookId { get => notebookId; set => notebookId = value; }
        public string NotebookName { get => notebookName; set => notebookName = value; }
        public string DateCreate { get => dateCreate; set => dateCreate = value; }
        public int UserId1 { get => UserId; set => UserId = value; }

        public Notebooks()
        {
        }

        public Notebooks(int notebookId, string notebookName, string dateCreate, int userId1)
        {
            NotebookId = notebookId;
            NotebookName = notebookName;
            DateCreate = dateCreate;
            UserId1 = userId1;
        }

        public Notebooks(string notebookName, string dateCreate, int userId1)
        {
            NotebookName = notebookName;
            DateCreate = dateCreate;
            UserId1 = userId1;
        }
    }
}
