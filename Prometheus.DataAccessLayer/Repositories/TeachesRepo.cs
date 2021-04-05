using Prometheus.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.DataAccessLayer.Repositories
{
    public class TeachesRepo
    {
        public bool InsertTeaches(int teacherID, int courseID)
        {
            try
            {
                
                    //SqlConnection connection;
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("InsertTeaches", connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure

                            SqlParameter teacherIDParam = new SqlParameter("@TeacherID", teacherID);
                            SqlParameter courseIDParam = new SqlParameter("@CourseID", courseID);


                            sqlCommand.Parameters.Add(teacherIDParam);
                            sqlCommand.Parameters.Add(courseIDParam); 


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

        public bool UpdateTeaches(Teaches teaches)
        {
            try
            {
                if (teaches != null)
                {
                    //SqlConnection connection;
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.USERUPDATEPASSWORD, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure


                            SqlParameter teacherID = new SqlParameter("@TeacherID", teaches.TeacherID);
                            SqlParameter courseID = new SqlParameter("@CourseID", teaches.CourseID);


                            sqlCommand.Parameters.Add(teacherID);
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

        public bool DeleteTeaches(Teaches teaches)
        {
            try
            {
                if (teaches != null)
                {
                    //SqlConnection connection;
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.DELETEUSER, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
                            SqlParameter teacherID = new SqlParameter("@TeacherID", teaches.TeacherID);
                            
                            sqlCommand.Parameters.Add(teacherID);
                           
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

        public List<Teaches> GetAllTeaches()
        {
            List<Teaches> userList;
            try
            {
                userList = new List<Teaches>();
                DataSet dataSet = new DataSet();
                //SqlConnection connection;
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETEACHES, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
                userList = dataSet.Tables["Table"].AsEnumerable()
                                .Select(dataRow => new Teaches
                                {
                                    TeacherID = dataRow.Field<int>("TeacherID"),
                                    CourseID = dataRow.Field<int>("CourseID")
                                }).ToList();
                
            }
            catch (Exception)
            {
                throw;
            }
            return userList;
        }
        /*
        public User GetTeachesByID(string id)
        {
            User user;
            try
            {
                DataSet dataSet = new DataSet();
                //SqlConnection connection;
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new
                        SqlCommand(Database.GETUSERBYID, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        //Defining parameters for StoredProcedure
                        SqlParameter teacherID = new SqlParameter("@TeacherID", id);
                        sqlCommand.Parameters.Add(teacherID);

                        connection.Open();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
                try
                {
                    DataRow dataRowOfUser = dataSet.Tables["Table"].AsEnumerable()
                                .SingleOrDefault(dataRow => dataRow.Field<string>("TeacherID") == id);
                    if (dataRowOfUser != null)
                    {
                        teaches = new Teaches
                        {
                           TeacherID = dataRowOfUser.Field<string>("TeacherID"),
                            CourseID = dataRowOfUser.Field<string>("CourseID")
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }*/
    }
}
