using Infrastructure.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Services;
using System;

namespace GelatechTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testUserCorrect()
        {
            //Arrange
            User testUser = new User();
            testUser.Username = "miranda.vj";
            testUser.Password = "123456";

            //Act: Ejecucion de pasos para obtener el resultado esperado
            ServiceUsers service = new ServiceUsers();
            var obtainedResult = service.GetUser(testUser);

            //Assert
            Assert.IsNotNull(obtainedResult);
        }

        [TestMethod]
        public void testUserIncorrect()
        {
            //Arrange
            User testUser = new User();
            testUser.Username = "miranda.kl";
            testUser.Password = "123456";

            //Act: Ejecucion de pasos para obtener el resultado esperado
            ServiceUsers service = new ServiceUsers();
            var obtainedResult = service.GetUser(testUser);

            //Assert
            Assert.IsNull(obtainedResult);
        }

        [TestMethod]
        public void testInvoiceCreation()
        {
            //Arrange



            //Act: Ejecucion de pasos para obtener el resultado esperado



            //Assert



        }

        [TestMethod]
        public void testInvoiceCancelation()
        {
            //Arrange



            //Act: Ejecucion de pasos para obtener el resultado esperado



            //Assert



        }

        [TestMethod]
        public void testInvoiceQtyNegative()
        {
            //Arrange



            //Act: Ejecucion de pasos para obtener el resultado esperado



            //Assert



        }

        [TestMethod]
        public void testInvoicePayCero()
        {
            //Arrange



            //Act: Ejecucion de pasos para obtener el resultado esperado



            //Assert



        }

        [TestMethod]
        public void testInvoiceDiscount()
        {
            //Arrange



            //Act: Ejecucion de pasos para obtener el resultado esperado



            //Assert



        }

        [TestMethod]
        public void testInvoiceNoDiscount()
        {
            //Arrange



            //Act: Ejecucion de pasos para obtener el resultado esperado



            //Assert



        }

        [TestMethod]
        public void testInvoicePromotion()
        {
            //Arrange



            //Act: Ejecucion de pasos para obtener el resultado esperado



            //Assert



        }

        [TestMethod]
        public void testInvoiceNoPromotion()
        {
            //Arrange



            //Act: Ejecucion de pasos para obtener el resultado esperado



            //Assert



        }
    }
}
