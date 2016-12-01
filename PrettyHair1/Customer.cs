using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair1
{
    public class Customer
    {
        public string Phone { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer()
        {

        }
        public Customer(string firstName, string lastName, string phone)
        {
            FirstName = firstName;
            LastName= lastName;
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
        
    }
}

