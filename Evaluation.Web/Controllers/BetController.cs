using Evaluation.Web.Enums;
using Evaluation.Web.Models;
using Evaluation.Web.Service;
using Evaluation.Web.ViewModel;
using Evaluation.Web.Extensions;
using System.Linq;
using System.Web.Http;
using System.Net.Http;

namespace Evaluation.Web.Controllers
{

    public class BetController : ApiController
    {
        [HttpGet]
        public PagedResult<CustomerBetVM> CustomerBets(BetTableSortBy sortBy, bool isAscending)
        {
            var service = new CustomerBetService(new HttpClient());
            var customers = service.GetCustomers();
            var bets = service.GetBets();

            var result = customers
                .Join(bets, cust => cust.Id, bet => bet.CustomerId,
                    (cust, bet) => new CustomerBetVM() {
                        CustomerName = cust.Name,
                        RaceNumber = bet.RaceId,
                        ReturnStake = bet.ReturnStake,
                        Won = bet.Won
                    })
                .OrderBy(sortBy.ToString(), isAscending).ToList();
            
            return new PagedResult<CustomerBetVM>
            {
                Data = result,
                TotalCount = result.Count()
            };
        }
    }
}
