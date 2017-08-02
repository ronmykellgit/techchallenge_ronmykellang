using Evaluation.Web.Models;
using Evaluation.Web.Service;
using Evaluation.Web.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Evaluation.Web.Test
{
    [TestClass]
    public class CustomerBetServiceTest
    {

        [TestMethod]
        public void WhenGettingAllCustomersTheyShouldBeReturned()
        {
            // Arrange
            var customers = new[] {
                new Customer{Id = 1, Name = "Customer 1"},
                new Customer{Id = 2, Name = "Customer 2"}
            };

            var fakehandler = new TestDelegatingHandler<Customer[]>(customers);
            var fakeServer = new HttpServer(new HttpConfiguration(), fakehandler);
            var service = new CustomerBetService(new HttpClient(fakeServer));
            
            // Act
            var result = service.GetCustomers();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void WhenGettingAllBetsTheyShouldBeReturned()
        {
            // Arrange
            var bets = new[] {
                new Bet {CustomerId = 1, RaceId = 1, HorseId = 2, ReturnStake = 100.0m, Won = true },
                new Bet {CustomerId = 2, RaceId = 1, HorseId = 5, ReturnStake = 200.0m, Won = false },
                new Bet {CustomerId = 3, RaceId = 1, HorseId = 3, ReturnStake = 400.0m, Won = true },
                new Bet {CustomerId = 4, RaceId = 1, HorseId = 2, ReturnStake = 100.0m, Won = false },
                new Bet {CustomerId = 5, RaceId = 1, HorseId = 1, ReturnStake = 500.0m, Won = false },
                new Bet {CustomerId = 6, RaceId = 1, HorseId = 5, ReturnStake = 2100.0m, Won = true },
                new Bet {CustomerId = 7, RaceId = 1, HorseId = 2, ReturnStake = 100.0m, Won = false },
            };
            var fakehandler = new TestDelegatingHandler<Bet[]>(bets);
            var fakeServer = new HttpServer(new HttpConfiguration(), fakehandler);
            var service = new CustomerBetService(new HttpClient(fakeServer));

            // Act
            var result = service.GetBets();

            // Assert
            Assert.AreEqual(7, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public void WhenGettingAnInvalidBookItShouldThrow()
        {
            // Arrange
            var fakeHandler = new TestDelegatingHandler<Customer>(HttpStatusCode.NotFound);
            var fakeServer = new HttpServer(new HttpConfiguration(), fakeHandler);
            var service = new CustomerBetService(new HttpClient(fakeServer));
            
            // Act
            var result = service.GetCustomers();

            // Assert
            Assert.Fail();
        }
        
    }
}
