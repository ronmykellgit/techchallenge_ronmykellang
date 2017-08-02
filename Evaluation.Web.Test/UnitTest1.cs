using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Evaluation.Web.Service;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using Evaluation.Web.Models;

namespace Evaluation.Web.Test
{
    [TestClass]
    public class CustomerBetServiceTest
    {
       
        [TestMethod]
        public void ExternalApiCall_Returns_Good_Data()
        {

            // Arrange
            var mockService = new Mock<CustomerBetService>();
            var mockHttpClient = new Mock<HttpClient>();

            var fakeHttpResponseMessage = new HttpResponseMessage() { StatusCode = HttpStatusCode.Accepted};

            mockService.Setup(service => mockHttpClient.Object.GetAsync(It.IsAny<string>()).Result).Returns(fakeHttpResponseMessage);

            // var fakeHttpResponseMessage = new HttpResponseMessage() { StatusCode = HttpStatusCode.Accepted };

            //mockService.SetupProperty(x => x._httpClient, mockHttpClient.Object);
            //mockService.Setup(service => mockHttpClient.Object.GetAsync(It.IsAny<string>()).Result)
            //    .Returns(fakeHttpResponseMessage);


            //.res fakeHttpResponseMessage);

            // Act


            // Assert
            mockService.Verify(a => a.ExternalApiCall<Customer>(It.IsAny<string>());
        }
    }
}
