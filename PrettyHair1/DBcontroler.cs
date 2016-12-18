using System;
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
                SqlCommand command = new SqlCommand("SP_INSERT_CUSTOMER", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FIRST_NAME", customer.FirstName));
                command.Parameters.Add(new SqlParameter("@LAST_NAME", customer.LastName));
                command.Parameters.Add(new SqlParameter("@PHONE_NUMBER", customer.Phone));
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

        public void InsertAppointment(Appointment appointment)
        {
            SqlConnection conn = getConnection();
            try
            {
                SqlCommand command = new SqlCommand("SP_INSERT_APPOINTMENT", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@APPOINTMENT_DATE", appointment.Date));
                command.Parameters.Add(new SqlParameter("@START_TIME", appointment.StartTime));
                command.Parameters.Add(new SqlParameter("@END_TIME", appointment.EndTime));
                command.Parameters.Add(new SqlParameter("@NOTES", appointment.Notes));
                command.Parameters.Add(new SqlParameter("@PHONE_NUMBER", appointment.Customer.Phone));
                command.ExecuteNonQuery();
                Console.WriteLine("Done!");
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    Console.WriteLine("You already have an appointment with that start time!");
                }
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

                using (SqlCommand phoneFromDbToList = new SqlCommand("SELECT PHONE_NUMBER FROM CUSTOMER", conn))
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



