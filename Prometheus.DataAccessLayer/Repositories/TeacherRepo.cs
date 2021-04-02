using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Prometheus.Entities;
using Prometheus.Exceptions;
namespace Prometheus.DataAccessLayer.Repositories
{
    public class TeacherRepo
    {
        static string conn = ConfigurationManager.ConnectionStrings["TeacherConnection"].ConnectionString;
        SqlConnection objCon = new SqlConnection(conn);
        SqlParameter[] objSqlParams;
        public bool AddTeacher(Teacher teachers)
        {
            try
            {
                if (teachers != null)
                {

                    using (var connection = new SqlConnection(conn))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("AddTeacher", connection))
                        {
                            connection.Open();
                            sqlCommand.CommandType = CommandType.StoredProcedure;


                            sqlCommand.Parameters.AddWithValue("@FName", teachers.FName);
                            sqlCommand.Parameters.AddWithValue("@LName", teachers.LName);
                            sqlCommand.Parameters.AddWithValue("@Address", teachers.Address);
                            sqlCommand.Parameters.AddWithValue("@DOB", teachers.DOB);
                            sqlCommand.Parameters.AddWithValue("@City", teachers.City);
                            sqlCommand.Parameters.AddWithValue("@MobileNo", teachers.MobileNo);
                            sqlCommand.Parameters.AddWithValue("@IsAdmin", teachers.isAdmin);
                            sqlCommand.Parameters.AddWithValue("@UserID", teachers.UserID);

                            sqlCommand.Parameters.AddRange(objSqlParams);

                            objCon.Open();
                            int affectedRows = sqlCommand.ExecuteNonQuery();
                            if (affectedRows > 0)
                                return true;
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return false;

        }
        public bool UpdateTeacher(Teacher teachers)
        {
            try
            {
                if (teachers != null)
                {

                    using (var connection = new SqlConnection(conn))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("UpdateTeacher", connection))
                        {
                            connection.Open();

                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@FName", teachers.FName);
                            sqlCommand.Parameters.AddWithValue("@LName", teachers.LName);
                            sqlCommand.Parameters.AddWithValue("@Address", teachers.Address);
                            sqlCommand.Parameters.AddWithValue("@DOB", teachers.DOB);
                            sqlCommand.Parameters.AddWithValue("@City", teachers.City);
                            sqlCommand.Parameters.AddWithValue("@MobileNo", teachers.MobileNo);
                            sqlCommand.Parameters.AddWithValue("@IsAdmin", teachers.isAdmin);
                            sqlCommand.Parameters.AddWithValue("@UserID", teachers.UserID);

                            sqlCommand.Parameters.AddRange(objSqlParams);

                            int affectedRows = sqlCommand.ExecuteNonQuery();
                            if (affectedRows > 0)
                                return true;
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return false;


        }
        public bool DeleteTeacher(Teacher teachers)
        {
            try
            {
                if (teachers != null)
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("DeleteTeacher", connection))
                        {
                            connection.Open();
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter objSqlParam_Id = new SqlParameter("@Id", teachers.TeacherID);
                            sqlCommand.Parameters.Add(objSqlParam_Id);

                            int affectedRows = sqlCommand.ExecuteNonQuery();
                            if (affectedRows > 0)
                                return true;
                        }
                    }


                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return false;
        }
        public Teacher SearchTeacher(int teacherid)
        {
            Teacher teachers;

            try
            {


                using (var connection = new SqlConnection(conn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("SearchTeacher", connection))
                    {
                        connection.Open();
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@TeacherId", teacherid);
                        int affectedRows = sqlCommand.ExecuteNonQuery();
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);

                        DataRow RowOfTeacher = dataSet.Tables["Teacher"].AsEnumerable()
                               .Single(dataRow => dataRow.Field<int>("TeacherID") == teacherid);

                        teachers = new Teacher
                        {
                            TeacherID = RowOfTeacher.Field<int>("TeacherID"),
                            FName = RowOfTeacher.Field<string>("FName"),
                            LName = RowOfTeacher.Field<string>("LName"),
                            Address = RowOfTeacher.Field<string>("Address"),
                            City = RowOfTeacher.Field<string>("City"),
                            UserID = RowOfTeacher.Field<string>("UserID"),
                            isAdmin = RowOfTeacher.Field<bool>("isAdmin"),
                            DOB = RowOfTeacher.Field<DateTime>("DOB"),
                            MobileNo = RowOfTeacher.Field<string>("MobileNo")
                        };
                        sqlCommand.Parameters.AddRange(objSqlParams);
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();


                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return teachers;
        }


        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers;
            try
            {
                DataSet dataSet = new DataSet();
                using (var connection = new SqlConnection(conn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("GetAllTeachers", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        //Creating an Adapter for connection
                        SqlDataAdapter objDA = new SqlDataAdapter(sqlCommand);
                        objDA.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        objDA.Fill(dataSet);

                    }

                }
                teachers = dataSet.Tables["Teacher"].AsEnumerable().
                                         Select(dataRow => new Teacher
                                         {
                                             TeacherID = dataRow.Field<int>("TeacherID"),
                                             FName = dataRow.Field<string>("FName"),
                                             LName = dataRow.Field<string>("LName"),
                                             UserID = dataRow.Field<string>("UserID"),
                                             Address = dataRow.Field<string>("Address"),
                                             DOB = dataRow.Field<DateTime>("DOB"),
                                             City = dataRow.Field<string>("City"),
                                             MobileNo = dataRow.Field<string>("MobileNo")
                                         }).ToList();

            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }

            return teachers;
        }
    }

}
