using System;
using System.Collections.Generic;

namespace MyLinqProject
{
    public static class Linq
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach (var elem in source)
            {
                if (elem.Equals(predicate))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
