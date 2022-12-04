using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using ORCLAPI.Models;
using System.Data;

namespace ORCLAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        OracleConnection conn = new OracleConnection("Data Source=(LQHDB =(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = lqhdb))));user id=API;password=API");

        int result = -1;
        [HttpGet]
        public IActionResult GetAllNote()
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            List<Notes> notes = new List<Notes>();
            //notebooks.Clear();
            OracleCommand command = new OracleCommand("SELECT * FROM NOTES", conn);
            OracleDataReader oracleDataReader = command.ExecuteReader();
            while (oracleDataReader.Read() && oracleDataReader != null)
            {
                notes.Add(new Notes(oracleDataReader.GetInt32(0), oracleDataReader.GetString(1), oracleDataReader.GetString(2), oracleDataReader.GetString(3),
                    oracleDataReader.GetInt32(4), oracleDataReader.GetInt32(5)));
                // return Ok(users);
            }
            if (notes.Count > 0)
            {
                return Ok(notes);
            }
            else
            {
                return Ok(notes);
            }


        }
        [HttpGet("{NotebookId}")]
        public IActionResult GetNotebyNotebookId(int NotebookId)
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            List<Notes> notes = new List<Notes>();
            OracleCommand command = new OracleCommand($"SELECT * FROM NOTES WHERE NotebookId='{NotebookId}'", conn);
            OracleDataReader oracleDataReader = command.ExecuteReader();
            while (oracleDataReader.Read() && oracleDataReader != null)
            {
                notes.Add(new Notes(oracleDataReader.GetInt32(0), oracleDataReader.GetString(1), oracleDataReader.GetString(2), oracleDataReader.GetString(3),
                     oracleDataReader.GetInt32(4), oracleDataReader.GetInt32(5)));
            }
            return Ok(notes);

        }
        //Add User
        [HttpPost("add")]
        public IActionResult AddUser(Notes notes)
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            OracleCommand oc = new OracleCommand($"INSERT INTO NOTES " +
                    $"(NoteName, NoteDetail, DateCreate, isFavorite, NotebookId) VALUES ('{notes.NoteName1}', " +
                    $"'{notes.NoteDetail1}', '{notes.DateCreate}', {notes.IsFavorite}, {notes.NotebookId})", conn);
            try
            {
                result = oc.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            if (result > 0)
            {
                return GetAllNote();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
