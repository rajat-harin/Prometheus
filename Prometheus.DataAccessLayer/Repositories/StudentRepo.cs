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
                            SqlParameter[] objSqlParams = new SqlParameter[7];
                            objSqlParams[0] = new SqlParameter("@Id", student.StudentID);
                            objSqlParams[1] = new SqlParameter("@FName", student.FName);
                            objSqlParams[2] = new SqlParameter("@LName", student.LName);
                            objSqlParams[2] = new SqlParameter("@UserName", student.UserName);
                            objSqlParams[3] = new SqlParameter("@Address", student.Address);
                            objSqlParams[4] = new SqlParameter("@DOB", student.DOB);
                            objSqlParams[5] = new SqlParameter("@City", student.City);
                            objSqlParams[6] = new SqlParameter("@MobileNo", student.MobileNo);

                            sqlCommand.Parameters.AddRange(objSqlParams);


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
                throw new PrometheusException(ex.Message);
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
                            SqlParameter[] objSqlParams = new SqlParameter[7];
                            objSqlParams[0] = new SqlParameter("@Id", student.StudentID);
                            objSqlParams[1] = new SqlParameter("@FName", student.FName);
                            objSqlParams[2] = new SqlParameter("@LName", student.LName);
                            objSqlParams[3] = new SqlParameter("@Address", student.Address);
                            objSqlParams[4] = new SqlParameter("@DOB", student.DOB);
                            objSqlParams[5] = new SqlParameter("@City", student.City);
                            objSqlParams[6] = new SqlParameter("@MobileNo", student.MobileNo);

                            sqlCommand.Parameters.AddRange(objSqlParams);


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
                throw new PrometheusException(ex.Message);
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
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
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
                                    UserName = dataRow.Field<string>("UserName"),
                                    Address = dataRow.Field<string>("Address"),
                                    DOB = dataRow.Field<DateTime>("DOB"),
                                    City = dataRow.Field<string>("City"),
                                    Password = dataRow.Field<string>("Password"),
                                    MobileNo = dataRow.Field<string>("MobileNo")
                                }).ToList();
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
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
                        SqlParameter[] objSqlParams = new SqlParameter[7];
                        objSqlParams[0] = new SqlParameter("@Id", student.StudentID);
                        objSqlParams[1] = new SqlParameter("@FName", student.FName);
                        objSqlParams[2] = new SqlParameter("@LName", student.LName);
                        objSqlParams[2] = new SqlParameter("@UserName", student.UserName);
                        objSqlParams[3] = new SqlParameter("@Address", student.Address);
                        objSqlParams[4] = new SqlParameter("@DOB", student.DOB);
                        objSqlParams[5] = new SqlParameter("@City", student.City);
                        objSqlParams[6] = new SqlParameter("@MobileNo", student.MobileNo);

                        objSqlParams[0].Direction = ParameterDirection.Input;
                        objSqlParams[1].Direction = ParameterDirection.Output;
                        objSqlParams[2].Direction = ParameterDirection.Output;
                        objSqlParams[3].Direction = ParameterDirection.Output;
                        objSqlParams[4].Direction = ParameterDirection.Output;
                        objSqlParams[5].Direction = ParameterDirection.Output;
                        objSqlParams[6].Direction = ParameterDirection.Output;

                        sqlCommand.Parameters.AddRange(objSqlParams);


                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
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
