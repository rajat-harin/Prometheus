using Prometheus.Entities;
using Prometheus.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.DataAccessLayer.Repositories
{
    public class StudentRepo
    {
        public bool InsertStudent(Student student)
        {
            try
            {
                if (student != null)
                {
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.INSERTSTUDENT, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
 
                            SqlParameter FName = new SqlParameter("@FName", student.FName);
                            SqlParameter LName = new SqlParameter("@Lname", student.LName);
                            SqlParameter UserID = new SqlParameter("@UserID", student.UserID);
                            SqlParameter Address = new SqlParameter("@Address", student.Address);
                            SqlParameter DOB = new SqlParameter("@DOB", student.DOB);
                            SqlParameter City = new SqlParameter("@City", student.City);
                            SqlParameter MobileNo = new SqlParameter("@MobileNo", student.MobileNo);
                            

                            sqlCommand.Parameters.Add(FName);
                            sqlCommand.Parameters.Add(LName);
                            sqlCommand.Parameters.Add(UserID);
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
            catch (Exception ex)
            {
                throw;
            }
            return false;
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                if (student != null)
                {
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.UPDATESTUDENT, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure

                            SqlParameter FName = new SqlParameter("@FName", student.FName);
                            SqlParameter LName = new SqlParameter("@Lname", student.LName);
                            SqlParameter UserID = new SqlParameter("@UserID", student.UserID);
                            SqlParameter Address = new SqlParameter("@Address", student.Address);
                            SqlParameter DOB = new SqlParameter("@DOB", student.DOB);
                            SqlParameter City = new SqlParameter("@City", student.City);
                            SqlParameter MobileNo = new SqlParameter("@MobileNo", student.MobileNo);


                            sqlCommand.Parameters.Add(FName);
                            sqlCommand.Parameters.Add(LName);
                            sqlCommand.Parameters.Add(UserID);
                            sqlCommand.Parameters.Add(Address);
                            sqlCommand.Parameters.Add(DOB);
                            sqlCommand.Parameters.Add(FName);
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

        public bool DeleteStudent(Student student)
        {
            try
            {
                if (student != null)
                {
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.DELETESTUDENT, connection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
                            SqlParameter objSqlParam_Id = new SqlParameter("@Id", student.StudentID);

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

        public List<Student> GetStudents()
        {
            List<Student> students;
            try
            {
                DataSet dataSet = new DataSet();
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETSTUDENTS, connection))
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
                students = dataSet.Tables["Student"].AsEnumerable()
                                .Select(dataRow => new Student
                                {
                                    StudentID = dataRow.Field<int>("StudentID"),
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
            
            return students;
        }

        public Student SearchStudent(int id)
        {
            Student student;
            try
            {
                DataSet objDS = new DataSet();
                student = new Student();
                student.StudentID = id;
                //Connection to database
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETENROLLMENTBYID, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        //Defining parameters for StoredProcedure

                        SqlParameter FName = new SqlParameter("@FName", student.FName);
                        SqlParameter LName = new SqlParameter("@Lname", student.LName);
                        SqlParameter UserID = new SqlParameter("@UserID", student.UserID);
                        SqlParameter Address = new SqlParameter("@Address", student.Address);
                        SqlParameter DOB = new SqlParameter("@DOB", student.DOB);
                        SqlParameter City = new SqlParameter("@City", student.City);
                        SqlParameter MobileNo = new SqlParameter("@MobileNo", student.MobileNo);


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
            return student;
        }

        //can be moved to different DAL
        /*
        //for use in homework repo
        public DataSet GetAssignedHomework(int id)
        {
            DataSet objDS = new DataSet();
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            SqlCommand objCom = new SqlCommand(Database.GETASSIGNEDHOMEWORK, objCon);
            //setting command type to stored procedure
            objCom.CommandType = CommandType.StoredProcedure;
            SqlParameter objSqlParams = new SqlParameter("@StudentID", id);
            objCom.Parameters.Add(objSqlParams);
            try
            {
                objCon.Open();
                //Creating an Adapter for connection
                SqlDataAdapter objDA = new SqlDataAdapter(objCom);
                objDA.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                objDA.Fill(objDS);
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            finally
            {
                objCon.Close();
            }
            return objDS;
        }
        */
    }
}
