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
    public class UserRepo
    {
        public bool InsertUser(User user)
        {
            try
            {
                if (user != null)
                {
                    //SqlConnection connection;
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.INSERTUSER, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure

                            SqlParameter userID = new SqlParameter("@UserID", user.UserID);
                            SqlParameter password = new SqlParameter("@Password", user.Password);
                            SqlParameter role = new SqlParameter("@Role", user.Role);


                            sqlCommand.Parameters.Add(userID);
                            sqlCommand.Parameters.Add(password);
                            sqlCommand.Parameters.Add(role);


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

        public bool UpdateUser(User user)
        {
            try
            {
                if (user != null)
                {
                    //SqlConnection connection;
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.USERUPDATEPASSWORD, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure

                            SqlParameter userID = new SqlParameter("@UserID", user.UserID);
                            SqlParameter password = new SqlParameter("@Password", user.Password);

                            sqlCommand.Parameters.Add(userID);
                            sqlCommand.Parameters.Add(password);

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

        public bool DeleteUser(User user)
        {
            try
            {
                if (user != null)
                {
                    //SqlConnection connection;
                    using (var connection = new SqlConnection(Database.ConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(Database.DELETEUSER, connection))
                        {
                            //setting command type to stored procedure
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            //Defining parameters for StoredProcedure
                            SqlParameter userID = new SqlParameter("@UserID", user.UserID);
                            sqlCommand.Parameters.Add(userID);
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

        public List<User> GetAllUsers()
        {
            List<User> userList;
            try
            {
                userList = new List<User>();
                DataSet dataSet = new DataSet();
                //SqlConnection connection;
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETALLUSERS, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
                userList = dataSet.Tables["Users"].AsEnumerable()
                                .Select(dataRow => new User
                                {
                                    UserID = dataRow.Field<string>("UserID"),
                                    Password = dataRow.Field<string>("Password"),
                                    Role = dataRow.Field<string>("Role")
                                }).ToList();
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            return userList;
        }

        public User GetUserByID(string id)
        {
            User user;
            try
            {
                DataSet dataSet = new DataSet();
                //SqlConnection connection;
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(Database.GETUSERBYID, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        //Defining parameters for StoredProcedure
                        SqlParameter courseID = new SqlParameter("@UserID", id);
                        sqlCommand.Parameters.Add(courseID);

                        connection.Open();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
                DataRow dataRowOfCourse = dataSet.Tables["Users"].AsEnumerable()
                                .Single(dataRow => dataRow.Field<string>("UserID") == id);
                user = new User
                {
                    UserID = dataRowOfCourse.Field<string>("UserID"),
                    Password = dataRowOfCourse.Field<string>("Password"),
                    Role = dataRowOfCourse.Field<string>("Role")
                };
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            return user;
        }

    }
}
