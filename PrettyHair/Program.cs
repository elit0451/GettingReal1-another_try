﻿
using System;
using System.Collections.Generic;
using System.Linq;
using PrettyHair1;
using System.Data.SqlClient;

namespace PrettyHair
{
    public class Program
    {
        string firstName = "";
        string lastName = "";
        string phone = "";
        Customer customer = new Customer();

        private static string connectionString =
           "Server=ealdb1.eal.local;Database=EJL67_DB;User ID=ejl67_usr;Password=Baz1nga67";

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }
        public void Run()
        {
            bool running = true;
            try
            {
                do
                {
                    int input = Menu();
                    switch (input)
                    {
                        case 1:
                            DBcontroler DB = new DBcontroler();
                            firstName = InsertCustomer("first name");
                            Console.Clear();
                            lastName = InsertCustomer("last name");
                            Console.Clear();
                            phone = InsertCustomer("telephone number");

                            customer.FirstName = customer.ChangeName(firstName);
                            customer.LastName = customer.ChangeName(lastName);
                            customer.Phone = customer.SplitPhoneNumber(phone);

                            DB.InsertCustomer(customer);
                            Console.WriteLine("Done");
                            Console.ReadKey();


                            break;

                           

                        /*  case 2: GetAllCustomers(); break;
                      case 7: SearchByLastName(); break;
                      case 9: Customers(); break;
                    */
                        case 10: running = false; break;

                    }
                    Console.Clear();
                } while (running);
            }
            catch (SqlException e)
            {
                Console.WriteLine("UPS " + e.Message);
                Console.ReadKey();
            }

            

        }
        private int Menu()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("1) Insert new customer");
            Console.WriteLine("2) Get all customers");
            Console.WriteLine("5) Search customers by phone number");
            Console.WriteLine("10) End program");
            Console.WriteLine();
            Console.WriteLine("Please input your command:");
            string input = Console.ReadLine();
            Console.Clear();
            int inputNum = Convert.ToInt32(input);
            return inputNum;
        }

        public bool CheckName(string firstname)
        {
            List<char> letters = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'æ', 'ø', 'å' };
            bool IsOnlyLetters = false;
            foreach (char character in firstname)
            {
                if (letters.Contains(character))
                {
                    IsOnlyLetters = true;
                }
                else
                {
                    IsOnlyLetters = false;
                }
            }
            return IsOnlyLetters;
        }
        public bool CheckPhoneNumberForSomethingDifferentThanDigits(string phone)
        {
            List<char> numbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool IsOnlyInts = false;
            foreach (char digit in phone)
            {
                if (phone.Contains(digit))
                {
                    IsOnlyInts = true;
                }
                else
                {
                    IsOnlyInts = false;
                }
            }
            return IsOnlyInts;
        }

        /* public void InitializeInput()
         {
             int y = 
             InsertCustomer()
         }*/
        public string InsertCustomer(string parameter)
        {
            string openingSentence = "Enter the " + parameter + " of the customer:";
            string message = "Wrong format! Please try again:";
            Console.WriteLine(openingSentence);
            string input = Console.ReadLine();
            switch (parameter)
            {
                case "first name":
                    if (CheckName(input) == false)
                    {
                        Console.WriteLine(message);
                        Console.ReadKey();
                        Console.Clear();
                        firstName = InsertCustomer(parameter);
                    }
                    break;
                case "last name":
                    if (CheckName(input) == false)
                    {
                        Console.WriteLine(message);
                        Console.ReadKey();
                        Console.Clear();
                        lastName = InsertCustomer(parameter);
                    }
                    break;
                case "telephone number":
                    if (customer.CheckPhoneNumberFormat(input) == false || CheckPhoneNumberForSomethingDifferentThanDigits(input) == false)
                    {
                        Console.WriteLine(message);
                        Console.ReadKey();
                        Console.Clear();
                        phone = InsertCustomer(parameter);
                    }
                    break;
            }
            return input;
        }
    }
}

