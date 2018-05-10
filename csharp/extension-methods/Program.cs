/// Extension Methods
///
/// Extension Methods add functions onto existing classes
/// They are syntactic sugar for normal static methods
/// Unlike a static method however, they may be invoked fluently.

using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Type a string to fizzle and press enter");
        var input = Console.ReadLine();
        var fizzedInput = input.Fizzle();
        // Note: @ before a string signifies a verbatim string
        //       $ before a string signifies an interpolated string
        Console.WriteLine(
$@"
You typed: {input}
Fizzed String: {fizzedInput}");
    }
}

// Extensions methods should be declared inside a static class.
public static class StringExtensions
{
    // Extension methods are defined as static methods.
    // The major difference is the use of the "this" keyword
    // on the first argument. This signifies what type
    // the extension method extends.
    //
    // Extension methods may be invoked like normal static
    // functions. StringExtensions.Fizzle("Hello") => "HelloFizz"
    // for example.
    public static string Fizzle(this string str)
    {
        return str + "Fizz";
    }
}