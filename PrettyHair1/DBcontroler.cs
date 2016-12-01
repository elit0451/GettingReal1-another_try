using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHair1;
using System.Data;
using System.Data.SqlClient;


namespace PrettyHair1
{
    public class DBcontroler
    {
        private SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection("Server=ealdb1.eal.local;Database=EJL67_DB;User ID=ejl67_usr;Password=Baz1nga67");
            conn.Open();
            return conn;
        }
        public void InsertCustomer(Customer customer)
        {
            SqlConnection conn = getConnection();
            try
            {
                SqlCommand command = new SqlCommand("spInsertCustomer", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@firstName",customer.FirstName ));
                command.Parameters.Add(new SqlParameter("@lastName", customer.LastName));
                command.Parameters.Add(new SqlParameter("@phone", customer.Phone));
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
      
    }
}

