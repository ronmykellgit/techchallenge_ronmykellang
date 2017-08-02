using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Evaluation.Web.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Order a string by property name and sorting orientation
        /// </summary>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, string propertyName, bool isAscending)
        {
            PropertyInfo prop = typeof(T).GetProperty(propertyName);
            if (isAscending)
            {
                return source.OrderBy(x => prop.GetValue(x, null));
            }
            return source.OrderByDescending(x => prop.GetValue(x, null));
        }
    }
}