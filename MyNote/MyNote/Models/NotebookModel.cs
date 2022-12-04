using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNote.Mobile.LoginRegister;

namespace MyNote.Models
{
    public class NotebookModel
    {
        public int notebookId { get; set; }
        public string notebookName { get; set; }
        public string dateCreate { get; set; }
        public int UserId { get; set; }

        public NotebookModel(int notebookId, string notebookName, string dateCreate, int userId)
        {
            this.notebookId = notebookId;
            this.notebookName = notebookName;
            this.dateCreate = dateCreate;
            UserId = userId;
        }
    }
}
