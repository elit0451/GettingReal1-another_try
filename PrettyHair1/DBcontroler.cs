using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace PrettyHair1
{
    public class DBcontroler
    {
        public SqlConnection getConnection()
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
                command.Parameters.Add(new SqlParameter("@firstName", customer.FirstName));
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

        public List<string> GetPhonesFromDB()
        {
            List<string> listofPhonesFromDB = new List<string>();
            using (SqlConnection conn = getConnection())
            {

                using (SqlCommand phoneFromDbToList = new SqlCommand("SELECT phone FROM GREAL_CUSTOMER", conn))
                {
                    using (SqlDataReader reader = phoneFromDbToList.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                                listofPhonesFromDB.Add(reader.GetString(0));
                        }
                    }
                }
                return listofPhonesFromDB;

            }

        }
    }
}



