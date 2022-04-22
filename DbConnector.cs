using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DisplayControl
{
    public class DbConnector
    {
        // Change this value to connect database
        private readonly string _connectionString = "Data Source=DESKTOP-77K4H3U;Initial Catalog=LearnDB;Integrated Security=True";

        #region Singleton
        private static DbConnector _instance;
        public static DbConnector Instance 
        {
            get 
            {
                if(_instance == null) 
                {
                    _instance = new DbConnector();
                }
                return _instance;
            }
        }
        #endregion

        public SqlConnection DBConnector;
        private DbConnector() 
        {
            Console.WriteLine("connect here");
            this.DBConnector = new SqlConnection(this._connectionString);
            this.DBConnector.Open();
            if(this.DBConnector.State == System.Data.ConnectionState.Open) 
            {
                Console.WriteLine("CONNECTED TO DATABASE");
            }
        }

        public void Insert(string query) 
        {
            SqlCommand cmd = new SqlCommand(query,this.DBConnector);
            try 
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"AN ERROR OCCURRED {ex}");
            }
        }
    }

    [System.Serializable]
    public class Result
    {
        public string passValue;
        public string failValue;
        public string result;
        public string sum;
        public Result(string _passValue, string _failValue, string _result, string _sum)
        {
            this.passValue = _passValue;
            this.failValue = _failValue;
            this.result = _result;
            this.sum = _sum;
        }
    }
}
