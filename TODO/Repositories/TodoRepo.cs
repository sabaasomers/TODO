using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Diagnostics;

namespace TODO
{
    public class TodoRepo
    {
        public TodoRepo ()
        {

            string connectionString = "URI=file:/Users/daniel/Projects/TODO/TODO/bin/TODO";
            IDbConnection dbcon;
            dbcon = (IDbConnection) new SqliteConnection(connectionString);
            dbcon.Open();
            IDbCommand dbcmd = dbcon.CreateCommand();
            // requires a table to be created named employee
            // with columns firstname and lastname
            // such as,
            //        CREATE TABLE employee (
            //           firstname varchar(32),
            //           lastname varchar(32));
            string sql =
                "SELECT * " +
                "FROM Tasks";
            dbcmd.CommandText = sql;
            IDataReader reader = dbcmd.ExecuteReader();
            while(reader.Read()) {
                var id = reader.GetInt16 (0);
                string name = reader.GetString (1);
                Debug.WriteLine("ID: " +
                    id.ToString() + " " + name);
            }
            // clean up
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;
        }
    }
}

