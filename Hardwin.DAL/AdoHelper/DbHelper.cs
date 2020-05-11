using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardwin.DAL.AdoHelper
{


    /// <summary>
    ///ConnectionForm provides methods to Connect And fetch or update database
    /// </summary>
    public class DbHelper
    {
        private SqlConnection con = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();
        private DataSet ds = new DataSet();

        public DbHelper()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["HardwinDb"].ConnectionString;
            cmd.Connection = con;
            da.SelectCommand = cmd;
        }

        public int NonQuery(string procedureName, params SqlParameter[] parameters)
        {

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.CommandText = procedureName;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return  cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public object GetScaler(string procedureName, params SqlParameter[] parameters)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.CommandText = procedureName;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public DataSet GetDateSet(string procedureName, params SqlParameter[] parameters)
        {
            try
            {
                ds.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedureName;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public void ClearTable(string TableName)
        {
            if (ds.Tables.Contains(TableName))
                ds.Tables[TableName].Clear();
        }
         
    }

}
