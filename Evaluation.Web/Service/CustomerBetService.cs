using Evaluation.Web.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace Evaluation.Web.Service
{

    /// <summary>
    /// A service class for customer bets 
    /// </summary>
    /// <remarks>
    /// Can be refactored/managed to a different project for services.
    /// </remarks>
    public class CustomerBetService
    {
        // can be broken down and also be placed to a config file
        private readonly string customerUrl = "https://whatech-customerbets.azurewebsites.net/api/GetCustomers?code=ra4hpMmJYPeCXQAkyCVmmXOFFX7sM/oTiDzt7AY9eIeuUcDlTcb83A==&name=ron";
        private readonly string betUrl = "https://whatech-customerbets.azurewebsites.net/api/GetBets?code=ra4hpMmJYPeCXQAkyCVmmXOFFX7sM/oTiDzt7AY9eIeuUcDlTcb83A==&name=ron";

        private readonly HttpClient _httpClient;

        /// <summary>
        /// If to refactor, create a IOC invoker for this.
        /// </summary>
        public CustomerBetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        /// <summary>
        /// Call external api to get customers
        /// </summary>
        public List<Customer> GetCustomers()
        {
            return ExternalApiCall<Customer>(customerUrl);
        }

        /// <summary>
        /// Call external api to get customer bets
        /// </summary>
        public List<Bet> GetBets()
        {
            return ExternalApiCall<Bet>(betUrl);
        }

        /// <summary>
        /// A synchronous http call to api
        /// </summary>
        public List<T> ExternalApiCall<T>(string url)
        {
            var response = _httpClient.GetAsync(url).Result;

            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsAsync<List<T>>().Result;
        }

    }
}