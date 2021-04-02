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
        public bool InsertTeacher(Teacher teacher)
        {
            bool Addteacher = false;
            SqlCommand sqlCommand = new SqlCommand("AddTeacher", objCon);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            
            SqlParameter FName = new SqlParameter("@FName", teacher.FName);
            SqlParameter LName = new SqlParameter("@Lname", teacher.LName);
            SqlParameter UserID = new SqlParameter("@UserID", teacher.UserID);
            SqlParameter Address = new SqlParameter("@Address", teacher.Address);
            SqlParameter DOB = new SqlParameter("@DOB", teacher.DOB);
            SqlParameter City = new SqlParameter("@City", teacher.City);
            SqlParameter MobileNo = new SqlParameter("@MobileNo", teacher.MobileNo);
            SqlParameter IsAdmin = new SqlParameter("@IsAdmin", teacher.IsAdmin);

            sqlCommand.Parameters.Add(FName);
            sqlCommand.Parameters.Add(LName); 
            sqlCommand.Parameters.Add(UserID);
            sqlCommand.Parameters.Add(Address);
            sqlCommand.Parameters.Add(DOB);
            sqlCommand.Parameters.Add(FName);
            sqlCommand.Parameters.Add(City);
            sqlCommand.Parameters.Add(MobileNo);
            sqlCommand.Parameters.Add(IsAdmin);

            try
            {
                objCon.Open();
                int affectedRows = sqlCommand.ExecuteNonQuery();
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

        public bool UpdateTeacher(Teacher  teacher)
        {
            bool Updateteacher = false;
            SqlCommand sqlCommand = new SqlCommand("UpdateTeacher", objCon);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter FName = new SqlParameter("@FName", teacher.FName);
            SqlParameter LName = new SqlParameter("@Lname", teacher.LName);
            SqlParameter UserID = new SqlParameter("@UserID", teacher.UserID);
            SqlParameter Address = new SqlParameter("@Address", teacher.Address);
            SqlParameter DOB = new SqlParameter("@DOB", teacher.DOB);
            SqlParameter City = new SqlParameter("@City", teacher.City);
            SqlParameter MobileNo = new SqlParameter("@MobileNo", teacher.MobileNo);
            SqlParameter IsAdmin = new SqlParameter("@IsAdmin", teacher.IsAdmin);

            sqlCommand.Parameters.Add(FName);
            sqlCommand.Parameters.Add(LName);
            sqlCommand.Parameters.Add(UserID);
            sqlCommand.Parameters.Add(Address);
            sqlCommand.Parameters.Add(DOB);
            sqlCommand.Parameters.Add(FName);
            sqlCommand.Parameters.Add(City);
            sqlCommand.Parameters.Add(MobileNo);
            sqlCommand.Parameters.Add(IsAdmin);

            try
            {
                objCon.Open();
                int affectedRows = sqlCommand.ExecuteNonQuery();
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

        public bool DeleteTeacher(Teacher teacher)
        {
            bool DeleteTeacher = false;
            SqlCommand sqlCommand = new SqlCommand("DeleteTeacher", objCon);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter FName = new SqlParameter("@FName", teacher.FName);
            SqlParameter LName = new SqlParameter("@Lname", teacher.LName);
            SqlParameter UserID = new SqlParameter("@UserID", teacher.UserID);
            SqlParameter Address = new SqlParameter("@Address", teacher.Address);
            SqlParameter DOB = new SqlParameter("@DOB", teacher.DOB);
            SqlParameter City = new SqlParameter("@City", teacher.City);
            SqlParameter MobileNo = new SqlParameter("@MobileNo", teacher.MobileNo);
            SqlParameter IsAdmin = new SqlParameter("@IsAdmin", teacher.IsAdmin);

            sqlCommand.Parameters.Add(FName);
            sqlCommand.Parameters.Add(LName);
            sqlCommand.Parameters.Add(UserID);
            sqlCommand.Parameters.Add(Address);
            sqlCommand.Parameters.Add(DOB);
            sqlCommand.Parameters.Add(FName);
            sqlCommand.Parameters.Add(City);
            sqlCommand.Parameters.Add(MobileNo);
            sqlCommand.Parameters.Add(IsAdmin);
            try
            {
                objCon.Open();
                int affectedRows = sqlCommand.ExecuteNonQuery();
                if (affectedRows > 0)
                    DeleteTeacher = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objCon.Close();
            }
            return DeleteTeacher;
        }

        public void SearchTeacher(int TeacherID)
        {
            SqlCommand objCom = new SqlCommand("SearchTeacher", objCon);
            objCom.CommandType = CommandType.StoredProcedure;
            //Defining parameters for StoredProcedure
            objCom.Parameters.AddWithValue("@TeacherID", TeacherID);
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers;
            try
            {
                DataSet dataSet = new DataSet();
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETALLUSERS, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        //Creating an Adapter for connection
                        SqlDataAdapter objDA = new SqlDataAdapter(sqlCommand);
                        objDA.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        objDA.Fill(dataSet);
                    }
                }
                teachers = dataSet.Tables["Teacher"].AsEnumerable()
                                .Select(dataRow => new Teacher
                                {
                                    TeacherID = dataRow.Field<int>("TeacherID"),
                                    FName = dataRow.Field<string>("FName"),
                                    LName = dataRow.Field<string>("LName"),
                                    UserID = dataRow.Field<string>("UserName"),
                                    Address = dataRow.Field<string>("Address"),
                                    DOB = dataRow.Field<DateTime>("DOB"),
                                    City = dataRow.Field<string>("City"),
                                    MobileNo = dataRow.Field<string>("MobileNo")
                                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return teachers;
        }

    
    }
}