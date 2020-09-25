using JokeAPI.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace JokeAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            int opt = 0;
            do
            {
                Console.WriteLine("=========================");
                Console.WriteLine("Choose the Type: ");
                Console.WriteLine("1 - Programming\n2 - Miscellaneous\n3 - Dark\n4 - Pun\n5 - Exit");
                opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        GetAPI("Programming").GetAwaiter().GetResult();
                        break;
                    case 2:
                        GetAPI("Miscellaneous").GetAwaiter().GetResult();
                        break;
                    case 3:
                        GetAPI("Dark").GetAwaiter().GetResult();
                        break;
                    case 4:
                        GetAPI("Pun").GetAwaiter().GetResult();
                        break;
                    case 5:
                        opt = 5;
                        break;
                    default:
                        Console.WriteLine("Option not Allowed");
                        opt = 0;
                        break;
                }
            } while (opt != 5);
        }

        public static async Task GetAPI(string choice)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://sv443.net/jokeapi/v2/joke/" + choice + "?type=single");
            HttpResponseMessage response = await client.SendAsync(request);
            Joke joke = JsonConvert.DeserializeObject<Joke>(await response.Content.ReadAsStringAsync());
            Console.WriteLine("Category: " + joke.category);
            Console.WriteLine("Joke: " + joke.joke);
        }
    }
}
