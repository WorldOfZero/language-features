/// LINQ - Language Integrated Query
/// Video: https://youtu.be/un3r1dW03VI
///
/// LINQ is a powerful feature of C# that enables you to easily query
/// data sources in a fluent API. LINQ is lazily evaluated and can be
/// used to access everything from simple arrays/lists to databases and
/// even online data sources (Twitter for example: https://github.com/JoeMayo/LinqToTwitter)
///
/// LINQ queries may be written in two different formats.
///
/// LINQ is built on top of C#'s Extension Method feature

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
     // List of 10 integers from 0-9
    static readonly List<int> integers = new List<int>(Enumerable.Range(0,10));

    static void Main(string[] args)
    {
        // Evaluate both syntaxs.
        var fluentResults = DoubleOddIntegersFluent(integers);
        var queryResults = DoubleOddIntegersQuery(integers);

        // LINQ is evaluated lazily, this means that even though we have
        // calculated the results above we DO NOT actually have the results
        // We need to "finalize" the function. This means that changes to
        // the list will still be included when the query is evaluated.

        // To avoid this we can force evaluation like this:
        var fluentEvaluatedResults = fluentResults.ToList();

        // Since we haven't forced evaluation of `queryResults` any
        // modifications made to the integers list will still effect it.
        integers.Add(11);

        // Now that we've added a value to our integers list lets force
        // the evaluation of queryResults. This is not required with LINQ
        // but because of lazy evaluation it is a good practice.
        // 
        // If you do not force evaluation complex calls like sorts can
        // be evaluated multiple times when they do not need to be.
        var queryEvaluatedResults = queryResults.ToList();

        // Now that we have two lists lets print them out.
        Console.WriteLine("Fluent List:");
        fluentEvaluatedResults.ForEach(value => Console.WriteLine($"\t {value}"));
        // Remember we added an extra value to the query list so we expect to see 22 as well.
        Console.WriteLine("Query List:");
        queryEvaluatedResults.ForEach(value => Console.WriteLine($"\t {value}"));
    }

    /// Double all odd integers in a list
    /// Implemented using LINQ's fluent syntax
    static IEnumerable<int> DoubleOddIntegersFluent(IEnumerable<int> ints)
    {
        return ints.Where((value) => value % 2 == 1).Select((value) => value * 2);
    }

    /// Double all odd integers in a list
    /// Implemented using LINQ's query syntax
    static IEnumerable<int> DoubleOddIntegersQuery(IEnumerable<int> ints)
    {
        return (from value in ints
                where value % 2 == 1
                select value * 2);
    }
}
