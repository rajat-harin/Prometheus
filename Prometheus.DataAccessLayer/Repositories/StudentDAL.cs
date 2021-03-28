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
    class StudentDAL
    {
        public bool InsertStudent(Student s)
        {
            bool studentInserted = false;
            //Connection to database
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            SqlCommand objCom = new SqlCommand(Database.INSERTSTUDENT, objCon);
            //setting command type to stored procedure
            objCom.CommandType = CommandType.StoredProcedure;

            //Defining parameters for StoredProcedure
            SqlParameter[] objSqlParams = new SqlParameter[7];
            objSqlParams[0] = new SqlParameter("@Id", s.StudentID);
            objSqlParams[1] = new SqlParameter("@FName", s.FName);
            objSqlParams[2] = new SqlParameter("@LName", s.LName);
            objSqlParams[3] = new SqlParameter("@Address", s.Address);
            objSqlParams[4] = new SqlParameter("@DOB", s.DOB);
            objSqlParams[5] = new SqlParameter("@City", s.City);
            objSqlParams[6] = new SqlParameter("@MobileNo", s.MobileNo);

            objCom.Parameters.AddRange(objSqlParams);

            try
            {
                objCon.Open();
                int affectedRows = objCom.ExecuteNonQuery();
                if(affectedRows > 0)
                    studentInserted = true;                
            }
            catch(Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            finally
            {
                objCon.Close();
            }
            return studentInserted;
        }

        public bool UpdateStudent(Student s)
        {
            bool studentUpdated = false;
            //Connection to database
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            SqlCommand objCom = new SqlCommand(Database.UPDATESTUDENT, objCon);
            //setting command type to stored procedure
            objCom.CommandType = CommandType.StoredProcedure;

            //Defining parameters for StoredProcedure
            SqlParameter[] objSqlParams = new SqlParameter[7];
            objSqlParams[0] = new SqlParameter("@Id", s.StudentID);
            objSqlParams[1] = new SqlParameter("@FName", s.FName);
            objSqlParams[2] = new SqlParameter("@LName", s.LName);
            objSqlParams[3] = new SqlParameter("@Address", s.Address);
            objSqlParams[4] = new SqlParameter("@DOB", s.DOB);
            objSqlParams[5] = new SqlParameter("@City", s.City);
            objSqlParams[6] = new SqlParameter("@MobileNo", s.MobileNo);

            objCom.Parameters.AddRange(objSqlParams);

            try
            {
                objCon.Open();
                int affectedRows = objCom.ExecuteNonQuery();
                if (affectedRows > 0)
                    studentUpdated = true;
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            finally
            {
                objCon.Close();
            }
            return studentUpdated;
        }

        public bool DeleteStudent(Student s)
        {
            bool studentDeleted = false;
            //Connection to database
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            SqlCommand objCom = new SqlCommand(Database.DELETESTUDENT, objCon);
            //setting command type to stored procedure
            objCom.CommandType = CommandType.StoredProcedure;

            //Defining parameters for StoredProcedure
            SqlParameter objSqlParam_Id = new SqlParameter("@Id", s.StudentID);

            objCom.Parameters.Add(objSqlParam_Id);

            try
            {
                objCon.Open();
                int affectedRows = objCom.ExecuteNonQuery();
                if (affectedRows > 0)
                    studentDeleted = true;
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            finally
            {
                objCon.Close();
            }
            return studentDeleted;
        }

        public DataSet GetStudents()
        {
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            SqlCommand objCom = new SqlCommand(Database.GETSTUDENTS, objCon);
            //setting command type to stored procedure
            objCom.CommandType = CommandType.StoredProcedure;
            try
            {
                objCon.Open();
                SqlDataAdapter objDA = new SqlDataAdapter(objCom);
                DataSet objDS = new DataSet();
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

        public Student SearchStudent(int id)
        {
            Student objStudent = new Student();
            objStudent.StudentID = id;
            //Connection to database
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            SqlCommand objCom = new SqlCommand(Database.SEARCHSTUDENT, objCon);
            //setting command type to stored procedure
            objCom.CommandType = CommandType.StoredProcedure;

            //Defining parameters for StoredProcedure
            SqlParameter[] objSqlParams = new SqlParameter[7];
            objSqlParams[0] = new SqlParameter("@Id", id);
            objSqlParams[1] = new SqlParameter("@FName", objStudent.FName);
            objSqlParams[2] = new SqlParameter("@LName", objStudent.LName);
            objSqlParams[3] = new SqlParameter("@Address", objStudent.Address);
            objSqlParams[4] = new SqlParameter("@DOB", objStudent.DOB);
            objSqlParams[5] = new SqlParameter("@City", objStudent.City);
            objSqlParams[6] = new SqlParameter("@MobileNo", objStudent.MobileNo);

            objSqlParams[0].Direction = ParameterDirection.Input;
            objSqlParams[1].Direction = ParameterDirection.Output;
            objSqlParams[2].Direction = ParameterDirection.Output;
            objSqlParams[3].Direction = ParameterDirection.Output;
            objSqlParams[4].Direction = ParameterDirection.Output;
            objSqlParams[5].Direction = ParameterDirection.Output;
            objSqlParams[6].Direction = ParameterDirection.Output;

            objCom.Parameters.AddRange(objSqlParams);

            try
            {
                objCon.Open();
                objCom.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            finally
            {
                objCon.Close();
            }
            return objStudent;
        }
    }
}
