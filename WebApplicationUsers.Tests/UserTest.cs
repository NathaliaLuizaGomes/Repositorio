using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationUsers.Models;

namespace WebApplicationUsers.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void UserFake()
        {
            // arranjo
            string emailEsperado = "maria@gmail.com";

            UsersSignupModel conta = new UsersSignupModel();
            // debita
            conta.Email = "maria@gmail.com";
            // assert
            string email = conta.Email;
            Assert.AreEqual(emailEsperado, email, "emailEsperado", "O email esperado está inccorreto");
        }
    }
}
