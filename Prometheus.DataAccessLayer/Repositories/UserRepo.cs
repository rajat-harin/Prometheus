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
                            SqlParameter securityQuestion = new SqlParameter("@SecurityQuestion", user.SecurityQuestion);
                            SqlParameter securityAnswer = new SqlParameter("@SecurityAnswer", user.SecurityAnswer);


                            sqlCommand.Parameters.Add(userID);
                            sqlCommand.Parameters.Add(password);
                            sqlCommand.Parameters.Add(role);
                            sqlCommand.Parameters.Add(securityQuestion);
                            sqlCommand.Parameters.Add(securityAnswer);


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
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
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
                userList = dataSet.Tables["Table"].AsEnumerable()
                                .Select(dataRow => new User
                                {
                                    UserID = dataRow.Field<string>("UserID"),
                                    Password = dataRow.Field<string>("Password"),
                                    Role = dataRow.Field<string>("Role"),
                                    SecurityQuestion = dataRow.Field<string>("SecurityQuestion"),
                                    SecurityAnswer = dataRow.Field<string>("SecurityAnswer")
                                }).ToList();
            }
            catch (Exception)
            {
                throw;
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
                    using (SqlCommand sqlCommand = new 
                        SqlCommand(Database.GETUSERBYID, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        //Defining parameters for StoredProcedure
                        SqlParameter userID = new SqlParameter("@UserID", id);
                        sqlCommand.Parameters.Add(userID);

                        connection.Open();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
                try
                {
                    DataRow dataRowOfUser = dataSet.Tables["Table"].AsEnumerable()
                                .SingleOrDefault(dataRow => dataRow.Field<string>("UserID") == id);
                    if (dataRowOfUser != null)
                    {
                        user = new User
                        {
                            UserID = dataRowOfUser.Field<string>("UserID"),
                            Password = dataRowOfUser.Field<string>("Password"),
                            Role = dataRowOfUser.Field<string>("Role")

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
            catch (Exception )
            {
                throw;
            }
            return user;
        }

        public User GetUser(string id)
        {
            User user;
            try
            {
                DataSet dataSet = new DataSet();
                //SqlConnection connection;
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new
                        SqlCommand(Database.GETUSER, connection))
                    {
                        //setting command type to stored procedure
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        //Defining parameters for StoredProcedure
                        SqlParameter userID = new SqlParameter("@UserID", id);
                        sqlCommand.Parameters.Add(userID);

                        connection.Open();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
                try
                {
                    DataRow dataRowOfUser = dataSet.Tables["Table"].AsEnumerable()
                        .SingleOrDefault(b => b.Field<string>("UserID") == id);
                    if (dataRowOfUser != null)
                    {
                        user = new User
                        {
                            UserID = dataRowOfUser.Field<string>("UserID"),
                            SecurityQuestion = dataRowOfUser.Field<string>("SecurityQuestion"),
                            SecurityAnswer = dataRowOfUser.Field<string>("SecurityAnswer")

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
        }
    }
}
