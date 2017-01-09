using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProxyWebService;
using ProxyWebService.Controllers;

namespace ProxyWebService.Tests.Controllers
{
    [TestClass]
    public class DefaultControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disponer
            DefaultController controller = new DefaultController();

            // Actuar
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("PWS", result.ViewBag.Title);
        }
    }
}
