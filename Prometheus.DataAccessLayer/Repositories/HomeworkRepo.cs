using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Prometheus.Entities;

namespace Prometheus.DataAccessLayer.Repositories
{
    public class HomeworkRepo
    {
        public bool AddHomework(Homework homework)///null or not
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand objCmd = new SqlCommand("AddHomeWork", connection))
                    {
                        connection.Open();
                        objCmd.CommandType = CommandType.StoredProcedure;

                        objCmd.Parameters.AddWithValue("@HomeworkID", homework.HomeworkID);
                        objCmd.Parameters.AddWithValue("@Description", homework.Description);
                        objCmd.Parameters.AddWithValue("@Deadline", homework.Deadline);
                        objCmd.Parameters.AddWithValue("@LongDescription", homework.LongDescription);
                        int affectedRows = objCmd.ExecuteNonQuery();
                        //return null;//success
                        if (affectedRows > 0)
                        {
                            return true;//success
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;// return error message
            }
            return false;
        }

        public bool UpdateHomework(Homework homework)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand objCmd = new SqlCommand("UpdateHomeWork", connection))
                    {
                        connection.Open();
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.AddWithValue("@Description", homework.Description);
                        objCmd.Parameters.AddWithValue("@Id", homework.HomeworkID);
                        objCmd.Parameters.AddWithValue("@Deadline", homework.Deadline);
                        objCmd.Parameters.AddWithValue("@LongDescription", homework.LongDescription);
                        int affectedRows = objCmd.ExecuteNonQuery();
                        //return null;//success
                        if (affectedRows > 0)
                        {
                            return true;//success
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;// return error message
            }
            return false;
        }

        public bool DeleteHomework(int homeworkId)
        {
            if (homeworkId != 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand objCmd = new SqlCommand("DeleteHomework", connection))
                        {
                            connection.Open();
                            objCmd.CommandType = CommandType.StoredProcedure;
                            objCmd.Parameters.AddWithValue("@id", homeworkId);
                            int affectedRows = objCmd.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return false;
        }
        public Homework SearchHomework(int HomeWorkID)
        {
            Homework homework;//
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand objCmd = new SqlCommand("SearchHomeWork", connection))
                    {
                        connection.Open();
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.AddWithValue("@Id", HomeWorkID);
                        int affectedRows = objCmd.ExecuteNonQuery();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objCmd);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);
                        //null or not null
                        DataRow RowOfHomework = dataSet.Tables["Homework"].AsEnumerable()
                            .Single(dataRow => dataRow.Field<int>("HomeworkID") == HomeWorkID);

                        homework = new Homework
                        {
                            HomeworkID = RowOfHomework.Field<int>("HomeworkID"),
                            Description = RowOfHomework.Field<string>("Description"),
                            Deadline = RowOfHomework.Field<DateTime>("Deadline"),
                            LongDescription = RowOfHomework.Field<string>("LongDescription")
                        };
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;// return error message
            }
            return homework;
        }

        public List<Homework> GetAllHomework()
        {
            List<Homework> homeworkList = new List<Homework>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand objCmd = new SqlCommand("GetAllHomework", connection))
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataAdapter sqldataAdapter = new SqlDataAdapter(objCmd);
                        DataSet dataset = new DataSet();
                        sqldataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqldataAdapter.Fill(dataset);
                        homeworkList = dataset.Tables[0].AsEnumerable().Select(
                        dataRow => new Homework
                        {
                            HomeworkID = dataRow.Field<int>("HomeworkID"),
                            Description = dataRow.Field<string>("Description"),
                            LongDescription = dataRow.Field<string>("LongDescription"),
                            ReqTime = dataRow.Field<DateTime>("ReqTime"),
                            Deadline = dataRow.Field<DateTime>("Deadline")
                        }).ToList();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return homeworkList;
        }
        //GetHomeworks()- add here<LIST>
    }
}
//use using to instantiate the sqlconnection and sqlcommand
//donot use parameters
//use try catch carefully at the starting itself
//Check whether your object is null or not so that exception is handled properly
