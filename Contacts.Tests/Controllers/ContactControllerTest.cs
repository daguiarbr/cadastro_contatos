using System.Web.Mvc;
using Contacts.Models;
using Contacts.Entities;
using Contacts.Controllers;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contacts.Tests
{

    [TestClass]
    public class ContactControllerTest
    {

        [TestMethod]
        public void TestIndexView()
        {
            var Dto = new DTOSearchContact();
            var controller = new ContactController();
            ViewResult result = controller.Index(Dto) as ViewResult;
            Assert.AreEqual("Listagem de Contatos", result.ViewBag.Message);
        }

        [TestMethod]
        public void TestIndexViewData()
        {
            var Dto = new DTOSearchContact();
            var allContacts = new List<Contact>();
            var controller = new ContactController();
            var result = controller.Index(Dto) as ViewResult;
            Assert.IsTrue(result.ViewData.Model is List<Contact>);
        }

        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new ContactController();
            var result = controller.Details(1) as ViewResult;
            Assert.AreEqual("Detalhes do Contato", result.ViewBag.Message);
        }

        [TestMethod]
        public void TestDetailsViewData()
        {
            var controller = new ContactController();
            var result = controller.Details(1) as ViewResult;
            var contact = (Contact)result.ViewData.Model;
            Assert.AreEqual("Douglas Golino Aguiar", contact.Name);
        }

        [TestMethod]
        public void TestCreateView()
        {
            var controller = new ContactController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.AreEqual("Cadastrar Contato", result.ViewBag.Message);
        }

        [TestMethod]
        public void TestEditView()
        {
            int Id = 1;
            var controller = new ContactController();
            ViewResult result = controller.Edit(Id) as ViewResult;
            Assert.AreEqual("Editar Contato", result.ViewBag.Message);
        }

        [TestMethod]
        public void TestDeleteView()
        {
            int Id = 1;
            var controller = new ContactController();
            ViewResult result = controller.Delete(Id) as ViewResult;
            Assert.AreEqual("Excluir Contato", result.ViewBag.Message);
        }

        [TestMethod]
        public void TestGetAddress()
        {
            var controller = new ContactController();
            var result = controller.GetAddress("17503-140") as JsonResult;
            var serializer = new JavaScriptSerializer();
            var output = serializer.Serialize(result.Data);
            Assert.AreEqual(@"{""City"":""Marília"",""Country"":""BR"",""Neighbourhood"":""São José"",""PostalCode"":""17503140"",""ShortCity"":""Marília"",""ShortNeighbourhood"":""S José"",""ShortStreet"":""R das Violetas"",""State"":""SP"",""Street"":""das Violetas""}", output);
        }
    }
}
