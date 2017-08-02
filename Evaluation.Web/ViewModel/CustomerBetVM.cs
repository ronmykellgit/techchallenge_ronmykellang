using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluation.Web.ViewModel
{
    public class CustomerBetVM
    {
        public string CustomerName { get; set; }
        public decimal ReturnStake { get; set; }
        public int RaceNumber { get; set; }
        public bool Won { get; set; }
    }
}