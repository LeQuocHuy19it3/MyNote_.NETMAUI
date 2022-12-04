using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ORCLAPI.Controllers
{
    public class DBConn
    {
        public static string connString = "Data Source=(LQHDB =(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = lqhdb))));user id=API;password=API";
        public static OracleConnection oc = new OracleConnection(connString);
        
    }
}
