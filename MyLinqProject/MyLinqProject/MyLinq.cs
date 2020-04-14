﻿using System;
using System.Collections.Generic;

namespace MyLinqProject
{
    public static class MyLinq
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach (var elem in source)
            {
                if (!predicate(elem))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach (var elem in source)
            {
                if (predicate(elem))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach (var elem in source)
            {
                if (predicate(elem))
                {
                    return elem;
                }
            }

            throw new InvalidOperationException();
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach (var elem in source)
            {
                yield return selector(elem);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach (var element in source)
            {
                foreach (var result in selector(element))
                {
                      yield return result;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
             this IEnumerable<TSource> source,
             Func<TSource, TKey> keySelector,
             Func<TSource, TElement> elementSelector)
        {
            if (source == null || keySelector == null || elementSelector == null)
            {
                throw new ArgumentNullException("source");
            }

            Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>();

            foreach (var elem in source)
            {
                dictionary.Add(keySelector(elem), elementSelector(elem));
            }

            return dictionary;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
    this IEnumerable<TFirst> first,
    IEnumerable<TSecond> second,
    Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("first");
            }

            List<TFirst> firstE = new List<TFirst>();
            List<TSecond> secondE = new List<TSecond>();

            foreach (var firstElem in first)
            {
                firstE.Add(firstElem);
            }

            foreach (var secondElem in second)
            {
                secondE.Add(secondElem);
            }

            int count = 0;

            if (firstE.Count > secondE.Count)
            {
                count = secondE.Count;
            }
            else
            {
                count = firstE.Count;
            }

            for (int i = 0; i < count; i++)
            {
                yield return resultSelector(firstE[i], secondE[i]);
            }
        }
    }
}
