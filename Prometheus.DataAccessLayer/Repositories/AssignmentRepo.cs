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
    public class AssignmentRepo
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["prometheusDb"].ConnectionString;

        public bool AddAssignment(Assignment assignment)
        {
            try
            {
                if(assignment !=  null)
                {
                    using(SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        using(SqlCommand objCmd = new SqlCommand("AddAssignment",connection))
                        {
                            connection.Open();
                            objCmd.CommandType = CommandType.StoredProcedure;
                            objCmd.Parameters.AddWithValue("@AssignmentID", assignment.AssignmentID);
                            objCmd.Parameters.AddWithValue("@HomeWorkID", assignment.HomeWorkID);
                            objCmd.Parameters.AddWithValue("@TeacherID", assignment.TeacherID);
                            objCmd.Parameters.AddWithValue("@CourseID", assignment.CourseID);
                            int affectedRows = objCmd.ExecuteNonQuery();
                            if(affectedRows > 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public bool UpdateAssignment(Assignment assignment)
        {
            try
            {
                if (assignment != null)
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        using (SqlCommand objCmd = new SqlCommand("UpdateAssignment", connection))
                        {
                            connection.Open();
                            objCmd.CommandType = CommandType.StoredProcedure;
                            objCmd.Parameters.AddWithValue("@AssignmentID", assignment.AssignmentID);
                            objCmd.Parameters.AddWithValue("@HomeWorkID", assignment.HomeWorkID);
                            objCmd.Parameters.AddWithValue("@TeacherID", assignment.TeacherID);
                            objCmd.Parameters.AddWithValue("@CourseID", assignment.CourseID);
                            int affectedRows = objCmd.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public bool DeleteAssignment(Assignment assignment)
        {
            try
            {
                if (assignment != null)
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        using (SqlCommand objCmd = new SqlCommand("DeleteAssignment", connection))
                        {
                            connection.Open();
                            objCmd.CommandType = CommandType.StoredProcedure;
                            objCmd.Parameters.AddWithValue("@AssignmentID", assignment.AssignmentID);
                            int affectedRows = objCmd.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public List<Assignment> GetAllAssignment()
        {
            List<Assignment> assignment = new List<Assignment>();
            try
            {
                if (assignment != null)
                {
                    DataSet dataset = new DataSet();
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        using (SqlCommand objCmd = new SqlCommand("GetAssignments", connection))
                        {
                            objCmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objCmd);
                            sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                            sqlDataAdapter.Fill(dataset);
                        }
                    }
                    assignment = dataset.Tables["Table"].AsEnumerable().Select(
                            dataRow => new Assignment
                            {
                                AssignmentID = dataRow.Field<int>("AssignmentID"),
                                CourseID = dataRow.Field<int>("CourseID"),
                                TeacherID = dataRow.Field<int>("TeacherID"),
                                HomeWorkID = dataRow.Field<int>("HomeWorkID"),

                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return assignment;
        }

        public Assignment SearchAssignmentById(int AssignmentID)
        {
            Assignment assignment;
            try
            {
                DataSet dataset = new DataSet();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand objCmd = new SqlCommand("SearchAssignment", connection))
                    {
                        connection.Open();
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.AddWithValue("@AssignmentID", AssignmentID);
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objCmd);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataset);
                    }
                }
                DataRow RowOfAssignment = dataset.Tables["Assignment"].AsEnumerable().
                            Single(Row => Row.Field<int>("AssignmentID") == AssignmentID
                            );

                assignment = new Assignment
                {
                    AssignmentID = RowOfAssignment.Field<int>("AssignmentID"),
                    HomeWorkID = RowOfAssignment.Field<int>("HomeWorkID"),
                    CourseID = RowOfAssignment.Field<int>("CourseID"),
                    TeacherID = RowOfAssignment.Field<int>("TeacherID")
                };
            }
            catch(Exception)
            {
                throw;
            }
            return assignment;
        }
    }
}
