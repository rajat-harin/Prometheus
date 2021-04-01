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
    public class EnrollmentRepo
    {
        public bool Insert(Enrollment enrollment)
        {
            try
            {
                if (enrollment != null)
                {
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.ADDENROLLMENT, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
                            SqlParameter studentID = new SqlParameter("@StudentID", enrollment.StudentID);
                            SqlParameter courseID = new SqlParameter("@CourseID", enrollment.CourseID);

                            sqlCommand.Parameters.Add(studentID);
                            sqlCommand.Parameters.Add(courseID);
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

        public bool Update(Enrollment enrollment)
        {
            try
            {
                if (enrollment != null)
                {
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.UPDATEENROLLMENT, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
                            SqlParameter enrollmentID = new SqlParameter("@EnrollmentID", enrollment.EnrollmentID);
                            SqlParameter studentID = new SqlParameter("@StudentID", enrollment.StudentID);
                            SqlParameter courseID = new SqlParameter("@CourseID", enrollment.CourseID);

                            sqlCommand.Parameters.Add(enrollmentID);
                            sqlCommand.Parameters.Add(studentID);
                            sqlCommand.Parameters.Add(courseID);
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
        } //Not Needed. Can be removed

        public bool Delete(Enrollment enrollment)
        {
            try
            {
                if (enrollment != null)
                {
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.DELETEENROLLMENT, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
                            SqlParameter enrollmentID = new SqlParameter("@EnrollmentID", enrollment.EnrollmentID);                           

                            sqlCommand.Parameters.Add(enrollmentID);
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

        public List<Enrollment> GetEnrollments()
        {
            List<Enrollment> enrollments;
            try
            {
                DataSet dataSet = new DataSet();
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETENROLLMENTS, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
                enrollments = dataSet.Tables["Table"].AsEnumerable()
                                .Select(dataRow => new Enrollment
                                {
                                    EnrollmentID = dataRow.Field<int>("EnrollmentID"),
                                    StudentID = dataRow.Field<int>("StudentID"),
                                    CourseID = dataRow.Field<int>("CourseID")
                                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return enrollments;
        }

        public Enrollment GetEnrollmentByID(int id)
        {
            Enrollment enrollment;
            try
            {
                DataSet dataSet = new DataSet();
                //SqlConnection connection;
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETENROLLMENTBYID, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        //Defining parameters for StoredProcedure
                        SqlParameter enrollmentID = new SqlParameter("@EnrollmentID", id);
                        sqlCommand.Parameters.Add(enrollmentID);

                        connection.Open();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
                DataRow dataRowOfEnrollment = dataSet.Tables["Table"].AsEnumerable()
                                .Single(dataRow => dataRow.Field<int>("EnrollmentID") == id);
                enrollment = new Enrollment
                {
                    EnrollmentID = dataRowOfEnrollment.Field<int>("EnrollmentID"),
                    StudentID = dataRowOfEnrollment.Field<int>("StudentID"),
                    CourseID = dataRowOfEnrollment.Field<int>("CourseID")
                };   
            }
            catch (Exception)
            {
                throw;
            }
            return enrollment;
        }
    }
}
