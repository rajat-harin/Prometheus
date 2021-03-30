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
    public class CourseDAL
    {
        public DataSet GetCourses()
        {
            DataSet objDS = new DataSet();
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            SqlCommand objCom = new SqlCommand(Database.GETCOURSES, objCon);
            //setting command type to stored procedure
            objCom.CommandType = CommandType.StoredProcedure;
            try
            {
                objCon.Open();
                //Creating an Adapter for connection
                SqlDataAdapter objDA = new SqlDataAdapter(objCom);
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
    }
}
