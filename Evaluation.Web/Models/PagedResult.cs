﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluation.Web.Models
{

    public class PagedResult<T>
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
    }

}