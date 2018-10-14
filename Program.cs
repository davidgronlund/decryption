using System;
using System.Linq;
namespace aggregate_practice
{
    class Program
    {
        static readonly string alphabet = "abcdefghijklmnopqrstuvwxyzåäö";
        static string crypto = "Pwzqemuözrözvykvvgt".ToLower();
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, alphabet.Length - 2)
                .Select(x => x);
            numbers.ToList().ForEach(displaceBy =>
            {
                var decrypted = crypto
                    .ToCharArray()
                    .Select(r =>
                    {
                        var index = (alphabet.IndexOf(r) - displaceBy) < 0 && crypto.Length >= displaceBy
                            ? alphabet.Length + (alphabet.IndexOf(r) - displaceBy)
                            : alphabet.IndexOf(r) - displaceBy;
                        return alphabet.Substring((index), 1);
                    })
                    .Aggregate((current, next) => current.ToString() + next.ToString())
                    .Replace("x", " ");
                Console.WriteLine(decrypted);
            });
        }
    }
}
