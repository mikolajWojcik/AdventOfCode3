using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = new Uri("https://adventofcode.com/2021/day/3/input");
            var count = 12;

            var accumulatedNumbers = new int[count];
            var listOfRecords = new List<string>();
            
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("cookie", "_ga=GA1.2.1029462445.1638344210; session=53616c7465645f5f9a5e19ea6eef045d8b1d6a50b62ba8cfe3509f809512b9eaa99c49a0b77d9fe0c04f4c55ccae7585; _gid=GA1.2.1726152084.1638543652");
                var response = await client.SendAsync(request);
                var stream = await response.Content.ReadAsStreamAsync();
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        var text = await reader.ReadLineAsync();

                        if (string.IsNullOrEmpty(text)) 
                            continue;
                        
                        listOfRecords.Add(text);

                        for (int i = 0; i < text.Length; i++)
                        {
                            var character = text[i].ToString();
                            int.TryParse(character, out var number);
                            accumulatedNumbers[i] += number;
                        }
                    }
                }
            }
            var gammaArrayBuilder = new StringBuilder();
            var epsilonArrayBuilder = new StringBuilder();

            for (var i = 0; i < count; i++)
            {
                if (accumulatedNumbers[i] > listOfRecords.Count / 2)
                {
                    gammaArrayBuilder.Append("1");
                    epsilonArrayBuilder.Append("0");
                }
                else
                {
                    gammaArrayBuilder.Append("0");
                    epsilonArrayBuilder.Append("1");
                }
            }
            
            var gammaText = gammaArrayBuilder.ToString();
            var epsilonText = epsilonArrayBuilder.ToString();

            var gamma = Convert.ToInt32(gammaText, 2);
            var epsilon = Convert.ToInt32(epsilonText, 2);
            
            var oxygenRating = RatingHelper.GetRating(count, listOfRecords.ToList(), true);
            var co2Rating = RatingHelper.GetRating(count, listOfRecords.ToList(), false);
            
            Console.WriteLine($"Gamma array: {gammaArrayBuilder}");
            Console.WriteLine($"Epsilon array: {epsilonArrayBuilder}");
            Console.WriteLine($"Gamma value: {gamma}");
            Console.WriteLine($"Epsilon array: {epsilon}");
            Console.WriteLine($"Power consumption {epsilon*gamma}");
            Console.WriteLine($"Oxygen rating {oxygenRating}");
            Console.WriteLine($"CO2 rating {co2Rating}");
            Console.WriteLine($"Result is {co2Rating*oxygenRating}");
        }
    }
    
}