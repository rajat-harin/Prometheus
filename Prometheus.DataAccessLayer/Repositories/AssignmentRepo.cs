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
    public class AssignmentRepo
    {
        public bool AddAssignment(Assignment assignment)
        {
            try
            {
                if (assignment != null)
                {
                    using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand objCmd = new SqlCommand("AddAssignment", connection))
                        {
                            connection.Open();
                            objCmd.CommandType = CommandType.StoredProcedure;
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

        public bool UpdateAssignment(Assignment assignment)
        {
            try
            {
                if (assignment != null)
                {
                    using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
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

        public bool DeleteAssignment(int AssignmentID)
        {
            try
            {
                if (AssignmentID != 0)
                {
                    using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand objCmd = new SqlCommand("DeleteAssignment", connection))
                        {
                            connection.Open();
                            objCmd.CommandType = CommandType.StoredProcedure;
                            objCmd.Parameters.AddWithValue("@AssignmentID", AssignmentID);
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

        public List<Assignment> GetAllAssignments()
        {
            List<Assignment> assignmentList = new List<Assignment>();
            try
            {
                if (assignmentList != null)
                {
                    using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand objCmd = new SqlCommand("GetAllAssignment", connection))
                        {
                            objCmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objCmd);
                            
                            DataSet dataset = new DataSet();
                            sqlDataAdapter.Fill(dataset);
                            assignmentList = dataset.Tables[0].AsEnumerable().Select(
                            dataRow => new Assignment
                            {
                                AssignmentID = dataRow.Field<int>("AssignmentID"),
                                TeacherID = dataRow.Field<int>("TeacherID"),
                                CourseID = dataRow.Field<int>("CourseID"),
                                HomeWorkID = dataRow.Field<int>("HomeWorkID"),

                            }).ToList();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return assignmentList;
        }

        public Assignment SearchAssignmentById(int AssignmentID)
        {
            Assignment assignment;
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand objCmd = new SqlCommand("SearchAssignment", connection))
                    {
                        connection.Open();
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.AddWithValue("@AssignmentID", AssignmentID);
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objCmd);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        DataSet dataset = new DataSet();
                        sqlDataAdapter.Fill(dataset);
                        DataRow RowOfAssignment = dataset.Tables["Assignment"].AsEnumerable().
                            Single(Row => Row.Field<int>("AssignmentID") == AssignmentID
                            );

                        assignment = new Assignment
                        {
                            HomeWorkID = RowOfAssignment.Field<int>("HomeWorkID"),
                            CourseID = RowOfAssignment.Field<int>("CourseID"),
                            TeacherID = RowOfAssignment.Field<int>("TeacherID")
                        };
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return assignment;
        }
    }
}
