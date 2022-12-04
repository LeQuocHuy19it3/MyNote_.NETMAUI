using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using ORCLAPI.Models;
using System.Data;

namespace ORCLAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotebookController : ControllerBase
    {
        OracleConnection conn = new OracleConnection("Data Source=(LQHDB =(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = lqhdb))));user id=API;password=API");
        
        int result = -1;
        [HttpGet]
        public IActionResult GetAllNotebook()
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            List<Notebooks> notebooks = new List<Notebooks>();
            //notebooks.Clear();
            OracleCommand command = new OracleCommand("SELECT * FROM NOTEBOOKS", conn);
            OracleDataReader oracleDataReader = command.ExecuteReader();
            while (oracleDataReader.Read() && oracleDataReader != null)
            {
                notebooks.Add(new Notebooks(oracleDataReader.GetInt32(0), oracleDataReader.GetString(1), oracleDataReader.GetString(2), oracleDataReader.GetInt32(3)));
                // return Ok(users);
            }
            if (notebooks.Count > 0)
            {
                return Ok(notebooks);
            }
            else
            {
                return Ok(notebooks);
            }


        }
        [HttpGet("{userId}")]
        public IActionResult GetNotebookbyUserId(int userId)
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            List<Notebooks> notebooks = new List<Notebooks>();
            OracleCommand command = new OracleCommand($"SELECT * FROM NOTEBOOKS WHERE UserId='{userId}'", conn);
            OracleDataReader oracleDataReader = command.ExecuteReader();
            while (oracleDataReader.Read() && oracleDataReader != null)
            {
                notebooks.Add(new Notebooks(oracleDataReader.GetInt32(0), oracleDataReader.GetString(1), oracleDataReader.GetString(2), oracleDataReader.GetInt32(3)));
                //return Ok(notebooks);
            }
            if (notebooks.Count > 0)
            {
                return Ok(notebooks);
            }
            else
            {
                return Ok(notebooks);
            }

        }
        //Add User
        [HttpPost("add")]
        public IActionResult AddUser(Notebooks notebooks)
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            OracleCommand oc = new OracleCommand($"INSERT INTO NOTEBOOKS " +
                    $"(NotebookName, DateCreate, UserId) VALUES ('{notebooks.NotebookName}', " +
                    $"'{notebooks.DateCreate}', {notebooks.UserId1})", conn);
            try
            {
                result = oc.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            if (result > 0)
            {
                return GetAllNotebook();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
