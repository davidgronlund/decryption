using System;
using System.Linq;
namespace Decryption
{
    class Program
    {
        static readonly string alphabet = "abcdefghijklmnopqrstuvwxyzåäö";
        static string crypto = "Pwzqemuözrözvykvvgt".ToLower();
        static void Main(string[] args)
        {
            Enumerable.Range(1, alphabet.Length - 2)
                .Select(x => x).ToList()
                .ForEach(displaceBy =>
                        Console.WriteLine(crypto
                            .ToCharArray()
                            .Select(r =>
                                alphabet.Substring(((alphabet.IndexOf(r) - displaceBy) < 0 && crypto.Length >= displaceBy
                                    ? alphabet.Length + (alphabet.IndexOf(r) - displaceBy)
                                    : alphabet.IndexOf(r) - displaceBy), 1)
                            )
                            .Aggregate((current, next) => current.ToString() + next.ToString())
                            .Replace("x", " "))
                );
        }
    }
}
