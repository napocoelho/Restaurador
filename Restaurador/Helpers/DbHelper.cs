using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Restaurador.Helpers
{
    public static class DbHelper
    {
        public static String ConnectionString
        {
            get
            {
                Config config = RegistryHelper.Load();

                if (config == null)
                    throw new NullReferenceException();

                string connectionString = "Initial Catalog=master;Data Source=" + config.Server.Host + ";User ID=" + config.Server.User + ";Password=" + config.Server.Password + ";Connect Timeout=10800;Application Name='Restaurador'";
                return connectionString;
            }
        }

        public static DataTable ExecuteTable(string sqlCommand)
        {
            DataTable data = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                
                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.CommandTimeout = connection.ConnectionTimeout;

                SqlDataReader reader = command.ExecuteReader();

                if (reader != null)
                {
                    data = new DataTable();
                    data.Load(reader, LoadOption.OverwriteChanges);
                }

                try
                {
                    connection.Close();
                }
                finally { }
            }

            return data;
        }

        public static Object ExecuteScalar(string sqlCommand, SqlConnection anExistentConnection = null)
        {
            Object data = null;

            if (anExistentConnection != null)
            {
                SqlCommand command = new SqlCommand(sqlCommand, anExistentConnection);
                command.CommandTimeout = anExistentConnection.ConnectionTimeout;
                data = command.ExecuteScalar();
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlCommand, connection);
                    command.CommandTimeout = connection.ConnectionTimeout;
                    data = command.ExecuteScalar();

                    try
                    {
                        connection.Close();
                    }
                    finally { }
                }
            }

            return data;
        }

        public static int ExecuteNonQuery(string sqlCommand, bool ignoreExceptions = false, SqlConnection openedConnection = null)
        {
            int count = 0;

            try
            {
                if (openedConnection != null)
                {
                    SqlCommand command = new SqlCommand(sqlCommand, openedConnection);
                    command.CommandTimeout = openedConnection.ConnectionTimeout;
                    count = command.ExecuteNonQuery();
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlCommand, connection);
                        command.CommandTimeout = connection.ConnectionTimeout;
                        count = command.ExecuteNonQuery();

                        try
                        {
                            connection.Close();
                        }
                        finally { }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!ignoreExceptions)
                    throw ex;
            }
            
            return count;
        }


        /// <summary>
        /// Kill all processes with the given [databaseName] and returns the killed processes number.
        /// </summary>
        public static int KillAllProcesses(string databaseName)
        {
            string script = "SELECT req_spid FROM master.dbo.syslockinfo WHERE RTRIM(LTRIM(db_name(rsc_dbid))) = '" + databaseName.Trim() + "'";
            int count = 0;

            DataTable tblProcesses = Helpers.DbHelper.ExecuteTable(script);

            foreach (DataRow process in tblProcesses.Rows)
            {
                Helpers.DbHelper.ExecuteNonQuery("kill " + process["req_spid"].ToString());
                count++;
            }

            return count;
        }
    }


    /*
    public class Field
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public Type Type { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    */


}
