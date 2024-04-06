using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BusinessLayerApplication;

namespace DataLayerApplication
{
    public class EmpLogicClass
    {
        
            
        public static string ConnectionString = "Data Source=DESKTOP-L5DGAO5;Initial Catalog=employee;user id=sa; password=Vijaya@123;Integrated Security=True ";

        public static EmployeeClass Emp;
        public DataSet getEmployeeData()
        {
            DataSet ds = Dataclass.GetData(ConnectionString, "DATA");
            return ds;
        }
        public int InsertData(EmployeeClass emp)
        {
            SqlParameter[] parms = new SqlParameter[7];
            parms[0] = new SqlParameter("@Firstname", SqlDbType.VarChar);
            parms[0].Value = emp.FIRSTNAME;
            parms[1] = new SqlParameter("@Lastname", SqlDbType.VarChar);
            parms[1].Value = emp.LASTNAME;
            parms[2] = new SqlParameter("@Gender", SqlDbType.VarChar);
            parms[2].Value = emp.GENDER;
            parms[3] = new SqlParameter("@Email", SqlDbType.VarChar);
            parms[3].Value = emp.EMAIL;
            parms[4] = new SqlParameter("@Mobile", SqlDbType.VarChar);
            parms[4].Value = emp.MOBILE;
            parms[5] = new SqlParameter("@state", SqlDbType.VarChar);
            parms[5].Value = emp.STATE;
            parms[6] = new SqlParameter("@country", SqlDbType.VarChar);
            parms[6].Value = emp.COUNTRY;
            return Dataclass.Modification(ConnectionString, "DATAINSERT", parms);

        }
        public int UpdateData(EmployeeClass emp)
        {
            SqlParameter[] parms = new SqlParameter[8];

            parms[0] = new SqlParameter("@Empno", SqlDbType.Int);
            parms[0].Value = emp.EMPNO;
            parms[1] = new SqlParameter("@Firstname", SqlDbType.VarChar);
            parms[1].Value = emp.FIRSTNAME;
            parms[2] = new SqlParameter("@Lastname", SqlDbType.VarChar);
            parms[2].Value = emp.LASTNAME;
            parms[3] = new SqlParameter("@Gender", SqlDbType.VarChar);
            parms[3].Value = emp.GENDER;
            parms[4] = new SqlParameter("@Email", SqlDbType.VarChar);
            parms[4].Value = emp.EMAIL;
            parms[5] = new SqlParameter("@Mobile", SqlDbType.VarChar);
            parms[5].Value = emp.MOBILE;
            parms[6] = new SqlParameter("@state", SqlDbType.VarChar);
            parms[6].Value = emp.STATE;
            parms[7] = new SqlParameter("@country", SqlDbType.VarChar);
            parms[7].Value = emp.COUNTRY;
            return Dataclass.Modification(ConnectionString, "DATAUPDATE", parms);
        }

        public int DeleteData(int CourseId)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@CourseId", SqlDbType.Int);
            parms[0].Value = CourseId;
            return Dataclass.Modification(ConnectionString, "DATADELETE", parms);

        }

        //public void UpdateData(EmployeeClass employee)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
