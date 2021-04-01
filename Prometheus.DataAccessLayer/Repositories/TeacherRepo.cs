using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Prometheus.Entities;

namespace Prometheus.DataAccessLayer.Repositories
{
    public class TeacherRepo
    {
        static string conn = ConfigurationManager.ConnectionStrings["TeacherConnection"].ConnectionString;
        SqlConnection objCon = new SqlConnection(conn);
        SqlParameter[] objSqlParams;
        public bool AddTeacher(Teacher T)
        {
            bool Addteacher = false;
            SqlCommand objCom = new SqlCommand("AddTeacher", objCon);
            objCom.CommandType = CommandType.StoredProcedure;
            objSqlParams = new SqlParameter[9];
            //Defining parameters for StoredProcedure
            objSqlParams[0] = new SqlParameter("@FName", T.FName);
            objSqlParams[1] = new SqlParameter("@LName", T.LName);
            objSqlParams[2] = new SqlParameter("@Address", T.Address);
            objSqlParams[3] = new SqlParameter("@DOB", T.DOB);
            objSqlParams[4] = new SqlParameter("@City", T.City);
            objSqlParams[5] = new SqlParameter("@MobileNo", T.MobileNo);
            objSqlParams[6] = new SqlParameter("@IsAdmin", T.isAdmin);
            objSqlParams[7] = new SqlParameter("@UserName", T.UserName);
            objSqlParams[8] = new SqlParameter("@Password", T.Password);
            objCom.Parameters.AddRange(objSqlParams);
            try
            {
                objCon.Open();
                int affectedRows = objCom.ExecuteNonQuery();
                if (affectedRows > 0)
                    Addteacher = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objCon.Close();
            }
            return Addteacher;
        }

        public bool UpdateTeacher(Teacher  T)
        {
            bool Updateteacher = false;
            SqlCommand objCom = new SqlCommand("UpdateTeacher", objCon);
            objCom.CommandType = CommandType.StoredProcedure;
            objSqlParams = new SqlParameter[9];
            //Defining parameters for StoredProcedure
            objSqlParams[0] = new SqlParameter("@FName", T.FName);
            objSqlParams[1] = new SqlParameter("@LName", T.LName);
            objSqlParams[2] = new SqlParameter("@Address", T.Address);
            objSqlParams[3] = new SqlParameter("@DOB", T.DOB);
            objSqlParams[4] = new SqlParameter("@City", T.City);
            objSqlParams[5] = new SqlParameter("@MobileNo", T.MobileNo);
            objSqlParams[6] = new SqlParameter("@TeacherID",T.TeacherID);
            objSqlParams[7] = new SqlParameter("@UserName", T.UserName);
            objSqlParams[8] = new SqlParameter("@Password", T.Password);
            objCom.Parameters.AddRange(objSqlParams);
            try
            {
                objCon.Open();
                int affectedRows = objCom.ExecuteNonQuery();
                if (affectedRows > 0)
                    Updateteacher = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objCon.Close();
            }
            return Updateteacher;
        }

        public void SearchTeacher(int TeacherID)
        {
            SqlCommand objCom = new SqlCommand("SearchTeacher", objCon);
            objCom.CommandType = CommandType.StoredProcedure;
            //Defining parameters for StoredProcedure
            objCom.Parameters.AddWithValue("@TeacherID", TeacherID);
        }
    }
}


