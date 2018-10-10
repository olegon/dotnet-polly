using System;
using System.Threading;
using Polly;

namespace dotnet_polly
{
    class Program
    {
        static void Main(string[] args)
        {
            var policy = Policy
            .Handle<FakeException>()
            .WaitAndRetry(
                3,
                retryAttempt => TimeSpan.FromSeconds(0.5 * retryAttempt),
                (exception, delay, retryCount, context) =>
                {
                    System.Console.Error.WriteLine(exception);
                }   
            );

            try
            {
                var number = policy.Execute(() =>
                {
                    var random = new Random();
                    int randomNumber = random.Next(20);

                    if (randomNumber < 10)
                    {
                        throw new FakeException();
                    }

                    return randomNumber;
                });

                System.Console.WriteLine($"Number: {number}");
            }
            catch (FakeException ex)
            {
                System.Console.Error.WriteLine(ex);
            }
        }
    }
}
