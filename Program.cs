using System;
using System.Linq;
namespace Decryption
{
    class Program
    {
        static readonly string alphabet = "abcdefghijklmnopqrstuvwxyzåäö";
        static readonly int displaceBy = 2;
        static void Main(string[] args)
        {
            var crypto = args[0]
                .ToLower();
            Console.WriteLine(crypto
                .ToCharArray()
                .Select(r =>
                    alphabet.Substring(((alphabet.IndexOf(r) - displaceBy) < 0 && crypto.Length >= displaceBy
                        ? alphabet.Length + (alphabet.IndexOf(r) - displaceBy)
                        : alphabet.IndexOf(r) - displaceBy), 1)
                )
                .Aggregate((current, next) => current.ToString() + next.ToString())
                .Replace("x", " ")
            );
        }
    }
}
