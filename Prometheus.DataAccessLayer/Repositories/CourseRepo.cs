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
    public class CourseRepo
    {
        
        public bool Insert(Course course)
        {
            try
            {
                if (course != null)
                {
                    //SqlConnection connection;
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.INSERTCOURSE, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure

                            SqlParameter courseID = new SqlParameter("@CourseID", course.CourseID);
                            SqlParameter name = new SqlParameter("@Name", course.Name);
                            SqlParameter startDate = new SqlParameter("@StartDate", course.StartDate);
                            SqlParameter endDate = new SqlParameter("@EndDate", course.EndDate);

                            sqlCommand.Parameters.Add(courseID);
                            sqlCommand.Parameters.Add(name);
                            sqlCommand.Parameters.Add(startDate);
                            sqlCommand.Parameters.Add(endDate);

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

        public bool UpdateCourse(Course course)
        {
            try
            {
                if (course != null)
                {
                    //SqlConnection connection;
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.UPDATECOURSE, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure

                            SqlParameter courseID = new SqlParameter("@CourseID", course.CourseID);
                            SqlParameter name = new SqlParameter("@Name", course.Name);
                            SqlParameter startDate = new SqlParameter("@StartDate", course.StartDate);
                            SqlParameter endDate = new SqlParameter("@EndDate", course.EndDate);

                            sqlCommand.Parameters.Add(courseID);
                            sqlCommand.Parameters.Add(name);
                            sqlCommand.Parameters.Add(startDate);
                            sqlCommand.Parameters.Add(endDate);

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

        public bool DeleteCourse(Course course)
        {
            try
            {
                if (course != null)
                {
                    //SqlConnection connection;
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.DELETECOURSE, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
                            SqlParameter courseID = new SqlParameter("@CourseID", course.CourseID);
                            sqlCommand.Parameters.Add(courseID);
                            connection.Open();
                            int affectedRows = sqlCommand.ExecuteNonQuery();
                            if (affectedRows > 0)
                                return true;
                        }
                    }
                }
                // NOTE: Ask if following should be done or not
                else
                {
                    throw new PrometheusException("Can not delete null object!");
                }
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            return false;
        }

        public List<Course> GetCourses()
        {
            List<Course> courseList; 
            try
            {
                courseList = new List<Course>();
                DataSet dataSet = new DataSet();
                //SqlConnection connection;
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETCOURSES, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
                courseList = dataSet.Tables["Table"].AsEnumerable()
                                .Select(dataRow => new Course
                                {
                                    CourseID = dataRow.Field<int>("CourseID"),
                                    Name = dataRow.Field<string>("Name"),
                                    StartDate = dataRow.Field<DateTime>("StartDate"),
                                    EndDate = dataRow.Field<DateTime>("EndDate")
                                }).ToList();
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            return courseList;
        }

        public Course GetCourseByID(int id)
        {
            Course course;
            try
            {
                DataSet dataSet = new DataSet();
                //SqlConnection connection;
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETCOURSEBYID, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        //Defining parameters for StoredProcedure
                        SqlParameter courseID = new SqlParameter("@CourseID", id);
                        sqlCommand.Parameters.Add(courseID);

                        connection.Open();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
                DataRow dataRowOfCourse = dataSet.Tables["Table"].AsEnumerable()
                                .Single(dataRow => dataRow.Field<int>("CourseID") == id);
                course = new Course
                {
                    CourseID = dataRowOfCourse.Field<int>("CourseID"),
                    Name = dataRowOfCourse.Field<string>("Name"),
                    StartDate = dataRowOfCourse.Field<DateTime>("StartDate"),
                    EndDate = dataRowOfCourse.Field<DateTime>("EndDate")
                };
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            return course;
        }

        /*
        // NOTE: FOLLOWING METHOD IS TO BE MOVED
        public List<Course> GetCoursesByStudentID(int id)
        {
            DataSet objDS = new DataSet();
            List<Course> courseList = new List<Course>();
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            SqlCommand objCom = new SqlCommand(Database.GETCOURSESOFSTUDENT, objCon);
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
                courseList = objDS.Tables[0].AsEnumerable()
                                .Select(dataRow => new Course
                                {
                                    CourseID = dataRow.Field<int>("CourseID"),
                                    Name = dataRow.Field<string>("Name"),
                                    StartDate = dataRow.Field<DateTime>("StartDate"),
                                    EndDate = dataRow.Field<DateTime>("EndDate")
                                }).ToList();
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            finally
            {
                objCon.Close();
            }
            return courseList;
        }
        */
    }
}
