using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayerApplication
{
    public class Dataclass
    {
        //Fetch data by giving Connection string and stored procedure name
        public static DataSet GetData(string con, string spName)
        {
            SqlConnection cn = new SqlConnection(con);
            SqlDataAdapter dad = new SqlDataAdapter(spName, con);
            DataSet ds = new DataSet();
            dad.Fill(ds);
            return ds;
        }
        public static int Modification(string con, string spName, SqlParameter[] parms)
        {
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            SqlCommand cm = new SqlCommand(spName, cn);
            cm.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in parms)
            {
                cm.Parameters.Add(p);
            }
            int rows = cm.ExecuteNonQuery();
            cn.Close();
            return rows;

        }

    }
}
