using MyNote.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.IService
{
    public interface INotebookService
    {
        Task<List<NotebookModel>> GetNotebookByUserId(int userId);
    }
}
