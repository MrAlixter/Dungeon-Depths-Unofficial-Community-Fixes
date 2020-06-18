using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Util
{
    public static T[] Values<T>()
        where T : struct, IComparable, IFormattable, IConvertible
    {
        Type type = typeof(T);

        if (!type.IsEnum) { throw new ArgumentException(); }

        return Enum.GetValues(type).Cast<T>().ToArray();
    }
}

public static class EnumerableExtension
{
    public static T PickRandom<T>(this IEnumerable<T> source)
    {
        return source.PickRandom(1).Single();
    }

    public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
    {
        return source.Shuffle().Take(count);
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        return source.OrderBy(x => Guid.NewGuid());
    }

    public static IEnumerable<T> Values<T>()
        where T : struct, IComparable, IFormattable, IConvertible
    {
        Type type = typeof(T);

        if(!type.IsEnum) { throw new ArgumentException(); }

        return Enum.GetValues(type).Cast<T>();
    }
}

