using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luxica_Store.Common
{
    public static class Pagination
    {
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize, out int rowCounts)
        {
            rowCounts = source.Count();
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
