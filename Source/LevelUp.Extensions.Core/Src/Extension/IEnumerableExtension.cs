﻿using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtension
{
    public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        HashSet<TKey> seenKeys = new HashSet<TKey>();
        foreach (TSource element in source)
        {
            var elementValue = keySelector(element);
            if (seenKeys.Add(elementValue))
            {
                yield return element;
            }
        }
    }

    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
            action(item);
    }

    public static IEnumerable<IEnumerable<T>> ToPermutations<T>(this IEnumerable<T> source)
    {
        return source.SelectMany((item, i) => source.Where((_, index) => index != i)
                .ToPermutations()
                .Select(subsequence => new[] { item }.Concat(subsequence)))
            .DefaultIfEmpty(Enumerable.Empty<T>());
    }
}
