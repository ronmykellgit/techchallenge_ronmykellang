using Evaluation.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Evaluation.Web.Service
{
    public class CustomerBetService
    {
        public HttpClient _httpClient;

        private readonly string customerUrl = "https://whatech-customerbets.azurewebsites.net/api/GetCustomers?code=ra4hpMmJYPeCXQAkyCVmmXOFFX7sM/oTiDzt7AY9eIeuUcDlTcb83A==&name=ron";
        private readonly string betUrl = "https://whatech-customerbets.azurewebsites.net/api/GetBets?code=ra4hpMmJYPeCXQAkyCVmmXOFFX7sM/oTiDzt7AY9eIeuUcDlTcb83A==&name=ron";
        
        public List<Customer> GetCustomers()
        {
            return ExternalApiCall<Customer>(customerUrl);
        }

        public List<Bet> GetBets()
        {
            return ExternalApiCall<Bet>(betUrl);
        }

        public List<T> ExternalApiCall<T>(string url)
        {
            try
            {
                using (var httpClient =  _httpClient ?? new HttpClient())
                {
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<List<T>>(result);
                    }
                }
            } catch (Exception ex)
            {
                // log exception
            }
            return null;
        }

    }
}