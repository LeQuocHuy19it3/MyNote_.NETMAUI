using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using ORCLAPI.Models;
using System.Data;

namespace ORCLAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        OracleConnection conn = new OracleConnection("Data Source=(LQHDB =(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = lqhdb))));user id=API;password=API");
        public static List<Users> users = new List<Users>();
        int result = -1;
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            users.Clear();
            OracleCommand command = new OracleCommand("SELECT * FROM USERS", conn);
            OracleDataReader oracleDataReader = command.ExecuteReader();
            while (oracleDataReader.Read() && oracleDataReader != null)
            {
                users.Add(new Users(oracleDataReader.GetInt32(0), oracleDataReader.GetString(1), oracleDataReader.GetString(2)));
               // return Ok(users);
            } 
            if (users.Count > 0)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }


        }
        [HttpGet("{username}/{password}")]
        public IActionResult UserLogin(string username, string password)
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            List<Users> userLogin = new List<Users>();
            OracleCommand command = new OracleCommand($"SELECT * FROM USERS WHERE Username='{username}' AND UserPass='{password}'", conn);
            OracleDataReader oracleDataReader = command.ExecuteReader();
            if (oracleDataReader.Read() && oracleDataReader != null)
            {
                userLogin.Add(new Users(oracleDataReader.GetInt32(0), oracleDataReader.GetString(1), oracleDataReader.GetString(2)));
                return Ok(userLogin);
            }
            else
            {
                return NotFound();
            }

        }
        //Add User
        [HttpPost("add")]
        public IActionResult AddUser(Users user)
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            OracleCommand oc = new OracleCommand($"INSERT INTO USERS " +
                    $"(Username, UserPass) VALUES ('{user.Name}', " +
                    $"'{user.Password}')", conn);
            try
            {
                result = oc.ExecuteNonQuery();
            } catch (Exception ex)
            {

            }
            if (result > 0)
            {
                return GetAllUsers();
            } else
            {
                return NotFound();
            }
        }
    }
}
