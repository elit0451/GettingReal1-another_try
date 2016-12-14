using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrettyHair1
{
    public class Customer
    {
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Dictionary<string, Customer> listofCustomers = new Dictionary<string, Customer>();
        CustomerRepository cuRepo = new CustomerRepository();
        public Dictionary<string, Customer> listOfCustomers { get; set; }
        public Customer()
        {

        }
        public Customer(string firstName, string lastName, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
        public string ChangeName(string name)
        {
            string holdingWord = "";
            string[] words = name.Split(' ');
            foreach (string word in words)
            {
                string firstLetter = word.Substring(0, 1);
                firstLetter = firstLetter.ToUpper();
                holdingWord = holdingWord + " " + firstLetter + word.Substring(1).ToLower();
            }
            return holdingWord.Trim();
        }
        public string SplitPhoneNumber(string phone)
        {
            phone = phone.Replace(" ", String.Empty);
            string number = phone.Insert(6, " ");
            number = number.Insert(4, " ");
            number = number.Insert(2, " ");
            return number;
        }
        public bool CheckPhoneNumberFormat(string phone)
        {
            bool IsEnoughLength = true;
            if (phone.Replace(" ", String.Empty).Length != 8)
            {
                IsEnoughLength = false;
            }
            else
            {
                IsEnoughLength = true;
            }
            return IsEnoughLength;
        }

        public bool Exists(string phone)
        {
            DBcontroler dbc = new DBcontroler();
            bool custExists = false;
            List<string> listOfPhonesFromDB = dbc.GetPhonesFromDB();
            foreach (string phoneNumber in listOfPhonesFromDB)
            {
                if (phoneNumber == phone)
                {
                    custExists = true;
                }
            }
            return custExists;
        }

        public bool RegisterCustomer(string firstName, string lastName, string phone)
        {
            bool isRegistered = false;
            if (Exists(phone) == false)
            {
                cuRepo.Create(firstName, lastName, phone);
                isRegistered = true;
            }
            return isRegistered;

        }
        public bool CheckPhoneNumberForSomethingDifferentThanDigits(string phone)
        {
            List<char> numbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool IsOnlyInts = true;
            foreach (char digit in phone)
            {
                if (numbers.Contains(digit) == false)
                {
                    IsOnlyInts = false;
                }
            }
            return IsOnlyInts;
        }
        public bool CheckName(string name)
        {
            List<char> letters = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'æ', 'ø', 'å', ' ' };
            bool IsOnlyLetters = true;
            foreach (char character in name)
            {
                if (letters.Contains(character) == false)
                {
                    IsOnlyLetters = false;
                }
            }
            return IsOnlyLetters;
        }
    }
}

