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
        public bool InsertTeacher(Teacher teacher)
        {
            try
            {
                if (teacher != null)
                {
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.INSERTTEACHER, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure

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
                            sqlCommand.Parameters.Add(City);
                            sqlCommand.Parameters.Add(MobileNo);
                            sqlCommand.Parameters.Add(IsAdmin);


                            connection.Open();
                            int affectedRows = sqlCommand.ExecuteNonQuery();
                            if (affectedRows > 0)
                                return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            try
            {
                if (teacher != null)
                {
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.UPDATETEACHER, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure

                            SqlParameter ID = new SqlParameter("@TeacherId", teacher.TeacherID);
                            SqlParameter FName = new SqlParameter("@FName", teacher.FName);
                            SqlParameter LName = new SqlParameter("@Lname", teacher.LName);
                            
                            SqlParameter Address = new SqlParameter("@Address", teacher.Address);
                            SqlParameter DOB = new SqlParameter("@DOB", teacher.DOB);
                            SqlParameter City = new SqlParameter("@City", teacher.City);
                            SqlParameter MobileNo = new SqlParameter("@MobileNo", teacher.MobileNo);
                            
                            sqlCommand.Parameters.Add(ID);
                            sqlCommand.Parameters.Add(FName);
                            sqlCommand.Parameters.Add(LName);
                            sqlCommand.Parameters.Add(Address);
                            sqlCommand.Parameters.Add(DOB);
                            sqlCommand.Parameters.Add(City);
                            sqlCommand.Parameters.Add(MobileNo);
                            
                            connection.Open();
                            int affectedRows = sqlCommand.ExecuteNonQuery();
                            if (affectedRows > 0)
                                return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool DeleteTeacher(Teacher teacher)
        {
            try
            {
                if (teacher != null)
                {
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.DELETETEACHER, connection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
                            SqlParameter objSqlParam_Id = new SqlParameter("@Id", teacher.TeacherID);

                            sqlCommand.Parameters.Add(objSqlParam_Id);


                            connection.Open();
                            int affectedRows = sqlCommand.ExecuteNonQuery();
                            if (affectedRows > 0)
                                return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers;
            try
            {
                DataSet dataSet = new DataSet();
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETTEACHERS, connection))
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
                teachers = dataSet.Tables["Table"].AsEnumerable()
                                .Select(dataRow => new Teacher
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
            catch (Exception)
            {
                throw;
            }

            return teachers;
        }

        public Teacher SearchTeacher(int id)
        {
            Teacher teacher;
            try
            {
                DataSet objDS = new DataSet();
                teacher = new Teacher();
                teacher.TeacherID = id;
                //Connection to database
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETTEACHERBYID, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        //Defining parameters for StoredProcedure

                        SqlParameter FName = new SqlParameter("@FName", teacher.FName);
                        SqlParameter LName = new SqlParameter("@Lname", teacher.LName);
                        SqlParameter UserID = new SqlParameter("@UserID", teacher.UserID);
                        SqlParameter Address = new SqlParameter("@Address", teacher.Address);
                        SqlParameter DOB = new SqlParameter("@DOB", teacher.DOB);
                        SqlParameter City = new SqlParameter("@City", teacher.City);
                        SqlParameter MobileNo = new SqlParameter("@MobileNo", teacher.MobileNo);


                        sqlCommand.Parameters.Add(FName);
                        sqlCommand.Parameters.Add(LName);
                        sqlCommand.Parameters.Add(UserID);
                        sqlCommand.Parameters.Add(Address);
                        sqlCommand.Parameters.Add(DOB);
                        sqlCommand.Parameters.Add(FName);
                        sqlCommand.Parameters.Add(City);
                        sqlCommand.Parameters.Add(MobileNo);


                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return teacher;
        }

     /*   //Enter Data in Teaches table
        public List<Teacher> TeacherCourses(int TeacherID, int CourseID)
        {
            try
            {
                if (TeacherID != 0 && CourseID != 0)
                {
                    using (SqlConnection connection = new SqlConnection())
                    {
                        using (SqlCommand objCmd = new SqlCommand("TeacherCourses", connection))
                        {
                            objCmd.CommandType = CommandType.StoredProcedure;
                            objCmd.Parameters.AddWithValue("@TeacherID", TeacherID);
                            objCmd.Parameters.AddWithValue("@CourseID", CourseID);
                            int affectedRows = objCmd.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }
     */

    }
}