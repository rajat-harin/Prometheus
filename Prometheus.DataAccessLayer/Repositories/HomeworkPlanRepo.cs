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
    public class HomeworkPlanRepo
    {
        public bool Insert(HomeworkPlan homeworkPlan)
        {
            try
            {
                if (homeworkPlan != null)
                {
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.ADDHOMEWORKPLAN, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
                            SqlParameter studentID = new SqlParameter("@StudentID", homeworkPlan.StudentID);
                            SqlParameter homeworkID = new SqlParameter("@HomeworkID", homeworkPlan.HomeworkID);
                            SqlParameter priorityLevel = new SqlParameter("@PriorityLevel", homeworkPlan.PriorityLevel);
                            SqlParameter isCompleted = new SqlParameter("@isCompleted", homeworkPlan.isCompleted);

                            sqlCommand.Parameters.Add(studentID);
                            sqlCommand.Parameters.Add(homeworkID);
                            sqlCommand.Parameters.Add(priorityLevel);
                            sqlCommand.Parameters.Add(isCompleted);

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

        public bool Update(HomeworkPlan homeworkPlan)
        {
            try
            {
                if (homeworkPlan != null)
                {
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.UPDATEHOMEWORKPLAN, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
                            SqlParameter studentID = new SqlParameter("@StudentID", homeworkPlan.StudentID);
                            SqlParameter homeworkID = new SqlParameter("@HomeworkID", homeworkPlan.HomeworkID);
                            SqlParameter priorityLevel = new SqlParameter("@PriorityLevel", homeworkPlan.PriorityLevel);
                            SqlParameter isCompleted = new SqlParameter("@isCompleted", homeworkPlan.isCompleted);

                            sqlCommand.Parameters.Add(studentID);
                            sqlCommand.Parameters.Add(homeworkID);
                            sqlCommand.Parameters.Add(priorityLevel);
                            sqlCommand.Parameters.Add(isCompleted);

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

        public bool Delete(HomeworkPlan homeworkPlan)
        {
            try
            {
                if (homeworkPlan != null)
                {
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.DELETEHOMEWORKPLAN, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
                            SqlParameter studentID = new SqlParameter("@StudentID", homeworkPlan.StudentID);
                            SqlParameter homeworkID = new SqlParameter("@HomeworkID", homeworkPlan.HomeworkID);

                            sqlCommand.Parameters.Add(studentID);
                            sqlCommand.Parameters.Add(homeworkID);
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

        public bool DeleteAll(int studentId)
        {
            try
            {
                
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.DELETEHOMEWORKPLANFORSTUDENT, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
                            SqlParameter studentID = new SqlParameter("@StudentID", studentId);

                            sqlCommand.Parameters.Add(studentID);
                          
                            connection.Open();
                            int affectedRows = sqlCommand.ExecuteNonQuery();
                            if (affectedRows > 0)
                                return true;
                        }
                    }
                
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public List<HomeworkPlan> GetHomeworkPlans()
        {
            List<HomeworkPlan> homeworkPlans;
            try
            {
                DataSet dataSet = new DataSet();
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETHOMEWORKPLAN, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
                homeworkPlans = dataSet.Tables["Table"].AsEnumerable()
                                .Select(dataRow => new HomeworkPlan
                                {
                                    StudentID = dataRow.Field<int>("StudentID"),
                                    HomeworkID = dataRow.Field<int>("HomeworkID"),
                                    PriorityLevel = dataRow.Field<int>("PriorityLevel"),
                                    isCompleted = dataRow.Field<bool>("isCompleted")
                                }).ToList();
                if (homeworkPlans.Any())
                {
                    return homeworkPlans;
                }
                else
                {
                    throw new PrometheusException("No Enrollments Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HomeworkPlan GetHomeworkPlanByKey(int studentId, int homeworkId)
        {
            HomeworkPlan homeworkPlan;
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
                        //Defining parameters for StoredProcedure
                        SqlParameter studentID = new SqlParameter("@StudentID", studentId);
                        SqlParameter homeworkID = new SqlParameter("@HomeworkID", homeworkId);

                        sqlCommand.Parameters.Add(studentID);
                        sqlCommand.Parameters.Add(homeworkID);

                        connection.Open();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
                DataRow dataRowOfPlan = dataSet.Tables["Table"].AsEnumerable()
                                .Single(dataRow => 
                                dataRow.Field<int>("StudentID") == studentId && dataRow.Field<int>("HomeworkID") == homeworkId);
                homeworkPlan = new HomeworkPlan
                {
                    StudentID = dataRowOfPlan.Field<int>("StudentID"),
                    HomeworkID = dataRowOfPlan.Field<int>("HomeworkID"),
                    PriorityLevel = dataRowOfPlan.Field<int>("PriorityLevel"),
                    isCompleted = dataRowOfPlan.Field<bool>("isCompleted")
                };
            }
            catch (Exception)
            {
                throw;
            }
            return homeworkPlan;
        }
    }
}
