using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationUsers.Models;
using WebApplicationUsers.Controllers;

namespace WebApplicationUsers.Test1
{
    [TestClass]
    public class UserTest
    {       
        [TestInitialize]
        public void InicializeTests()
        {

        }

        [TestMethod]
        public void UserSignupExist()
        {
            UsersSignupModel usersSignup = new UsersSignupModel();
            usersSignup.FirstName = "First Name";
            var resultFirstName = false;

            usersSignup.LastName = "First Name";
            var resultLastName = false;


            if (!String.IsNullOrEmpty(usersSignup.FirstName))
            {
                resultFirstName = true;
            }

            if (!String.IsNullOrEmpty(usersSignup.LastName))
            {
                resultLastName = true;
            }

            Assert.AreEqual(true, resultFirstName, "FirstName", "FirstName Not found");
            Assert.AreEqual(true, resultLastName, "LastName", "FirstName Not found");
        }

        [TestMethod]
        public void UserSignupDoesExist()
        {
            UsersSignupModel usersSignup = new UsersSignupModel();
            usersSignup.FirstName = "";
            var resultFirstName = false;

            usersSignup.LastName = "";
            var resultLastName = false;


            if (!String.IsNullOrEmpty(usersSignup.FirstName))
            {
                resultFirstName = true;
            }

            if (!String.IsNullOrEmpty(usersSignup.LastName))
            {
                resultLastName = true;
            }

            Assert.AreEqual(true, resultFirstName, "FirstName", "FirstName Not found");
            Assert.AreEqual(true, resultLastName, "LastName", "FirstName Not found");
        } 


        //Test
        [TestMethod]
        public void UserEmailDiferent()
        {
            // arranjo
            string emailEsperado = "maria@gmail.com";

            UsersSignupModel conta = new UsersSignupModel();
            // debita
            conta.Email = "jose@gmail.com";
            // assert
            string email = conta.Email;
            Assert.AreEqual(emailEsperado, email, emailEsperado, "Invalid fields");
        }

        [TestCleanup]
        public void FinishTests()
        {

        }
    }
}
