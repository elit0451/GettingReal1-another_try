
using System;
using System.Collections.Generic;
using PrettyHair1;
using System.Data.SqlClient;
using System.Data;

namespace PrettyHair
{
    public class UI
    {
        Customer customer = new Customer();

        private static string connectionString = "Server=ealdb1.eal.local;Database=EJL67_DB;User ID=ejl67_usr;Password=Baz1nga67";

        static void Main(string[] args)
        {
            UI myProgram = new UI();
            myProgram.Run();
        }
        public void Run()
        {
            Menu();
        }

        private int ChooseACommand()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("1) Insert new customer");
            Console.WriteLine("2) Get all customers");
            //Console.WriteLine("3) Search customers by phone number");
            Console.WriteLine("10) End program");
            Console.WriteLine();
            Console.WriteLine("Please choose a command:");

            int inputNum;
            if (Int32.TryParse(Console.ReadLine(), out inputNum) == false)
            {
                inputNum = 0;
            }
            Console.Clear();
            return inputNum;
        }
        public void Menu()
        {
            bool isRunning = true;
            do
            {
                int input = ChooseACommand();
                switch (input)
                {
                    case 1:
                        InsertCustomer();
                        break;
                    case 2: GetAllCustomers();
                        break;
                    /* case 7: SearchByLastName(); break;
                     case 9:
                         Customers(); break;
                         */
                    case 10: isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input! Try again!");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            } while (isRunning);
        }

        public void InsertCustomer()
        {
            string firstName = "";
            string lastName = "";
            string phone = "";
            DBcontroler DB = new DBcontroler();
            firstName = InputCustomer("first name");
            Console.Clear();
            lastName = InputCustomer("last name");
            Console.Clear();
            phone = InputCustomer("telephone number");

            customer.FirstName = customer.ChangeName(firstName);
            customer.LastName = customer.ChangeName(lastName);
            customer.Phone = customer.SplitPhoneNumber(phone);

            DB.InsertCustomer(customer);
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
        
        public string InputCustomer(string parameter)
        {
            bool isParOK = false;
            string input = "";
            while (isParOK == false)
            {
                string openingSentence = "Enter the " + parameter + " of the customer:";
                Console.WriteLine(openingSentence);
                input = Console.ReadLine();
                switch (parameter)
                {
                    case "first name":
                        isParOK = customer.CheckName(input);
                        break;
                    case "last name":
                        isParOK = customer.CheckName(input);
                        break;
                    case "telephone number":
                        isParOK = true;
                        if (customer.CheckPhoneNumberFormat(input) == false || customer.CheckPhoneNumberForSomethingDifferentThanDigits(input) == false)
                        {
                            isParOK = false;
                        }
                        break;
                }
                if (isParOK == false)
                {
                    Error();
                }
            }
            return input;
        }
        public void Error()
        {
            string errorMessage = "Wrong format! Please try again:";
            Console.WriteLine(errorMessage);
            Console.ReadKey();
            Console.Clear();
        }

        private void GetAllCustomers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmdGetAllCustomers = new SqlCommand("GetCustomers", con);
                cmdGetAllCustomers.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmdGetAllCustomers.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string CustomerLastName = reader["LastName"].ToString();
                        string CustomerFirstName = reader["FirstName"].ToString();
                        string CustomerPhoneNumber = reader["Phone"].ToString();

                        Console.WriteLine("First name -" + " " + CustomerFirstName);
                        Console.WriteLine("Last name -" + " " + CustomerLastName);
                        Console.WriteLine("Telephone number -" + " " + CustomerPhoneNumber);
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}

