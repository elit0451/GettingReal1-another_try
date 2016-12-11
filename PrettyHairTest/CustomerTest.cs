using PrettyHair1;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PrettyHairTest
{
    [TestClass]
    public class CustomerTests
    {
        private Customer customer;

        [TestInitialize]
        public void SetuoForTest()
        {
            customer = new Customer();
        }

        [TestMethod]
        public void ShouldCapitalizeFirstLetterInTheName()
        {
            customer.FirstName = "nina";
            Assert.AreEqual("Nina", customer.ChangeName(customer.FirstName));
        }

        [TestMethod]
        public void ShouldCapitalizeEveryWord()
        {
            customer.FirstName = "anna maria";
            Assert.AreEqual("Anna Maria", customer.ChangeName(customer.FirstName));
        }

        [TestMethod]
        public void ShouldCapitalizeFirstLetterButKeepTheRestLower()
        {
            customer.FirstName = "isAbella";
            Assert.AreEqual("Isabella", customer.ChangeName(customer.FirstName));
        }

        [TestMethod]
        public void ShouldCapitalizeFirstLetterButKeepTheRestLowerOnEveryWord()
        {
            customer.LastName = "fLOyd gREen";
            Assert.AreEqual("Floyd Green", customer.ChangeName(customer.LastName));
        }


        [TestMethod]
        public void ShouldSeparateEachPairOfNumbers()
        {
            customer.Phone = "22340942";
            Assert.AreEqual("22 34 09 42", customer.SplitPhoneNumber(customer.Phone));
        }

        [TestMethod]
        public void PhoneNumberHasWrongFormat()
        {
            customer.Phone = "29870";
            Assert.IsFalse(customer.CheckPhoneNumberFormat(customer.Phone));
        }

        [TestMethod]
        public void PhoneNumberHasGoodFormat()
        {
            customer.Phone = "74980225";
            Assert.IsTrue(customer.CheckPhoneNumberFormat(customer.Phone));
        }

        [TestMethod]
        public void ShouldDeleteWhiteSpacesFromTheImput()
        {
            customer.Phone = "223 4094 2";
            Assert.AreEqual("22 34 09 42", customer.SplitPhoneNumber(customer.Phone));
        }

        [TestMethod]
        public void ShouldNotInsertACustomerIfThePhoneIsTheSame()
        {
            customer.Phone = "12 34 56 78";
            Assert.IsTrue(customer.Exists(customer.Phone));
        }

        [TestMethod]
        public void ShouldInsertACustomerIfThePhoneIsDifferent()
        {
            customer.Phone = "44 44 44 44";
            Assert.IsFalse(customer.Exists(customer.Phone));
        }

    }
}


