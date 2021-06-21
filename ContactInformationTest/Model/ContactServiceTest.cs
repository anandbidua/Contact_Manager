using System;
using System.Web.ModelBinding;
using ContactsService;
using ContactsService.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContactInformationTest.Model
{
    [TestClass]
    public class ContactServiceTest
    {
        private IContactsService _service;

        [TestInitialize]
        public void Initialize()
        {
            //_mockService = new Mock<IContactsService>();
            //_modelState = new ModelStateDictionary();
            _service = new ContactsService.ContactsService();
        }
        [TestMethod]
        public void CreateContact()
        {
            var contact = new Contacts { Id = 1234, FirstName = "anand", LastName = "Bidua", Phone = "12345", Email = "anand.bidua@gmail.com" };

            // Act
            var result = _service.CreateContact(contact);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EditContact() {
            var contact = new Contacts { Id = 1234, FirstName = "anand", LastName = "Bidua", Phone = "12345", Email = "anand.bidua@gmail.com" };
            _service.CreateContact(contact);
            // Act
            var result = _service.EditContact(contact);

            // Assert
            Assert.IsTrue(result);
        }



    }
}
